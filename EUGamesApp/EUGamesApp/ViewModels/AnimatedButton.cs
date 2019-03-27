using EUGamesApp.Models;
using EUGamesApp.Views;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Toolkit.Effects;


namespace EUGamesApp.ViewModels
{
    public class AnimatedButton : ContentView
    {
        private Label _textLabel1;
        private Label _textLabel2;
        private Grid _grid;
        private StackLayout _layout;
        private Image _icon;
        private StackLayout _StackLayout;
        private Frame _result;
        private Image _image;
        private string TEMP;
        public static int counter;
        public static ObservableCollection<NearPlace> tempList;

        /// <summary>
        /// Creates a new instance of the animation button
        /// </summary>
        /// <param name="text">the text to set</param>
        /// <param name="callback">action to call when the animation is complete</param>
        /// 
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                SKRect rect = new SKRect(0, 0, Screen.WidthPixels, Screen.HeightPrixels);

                // Create linear gradient from upper-left to lower-right
                paint.Color = SKColor.FromHsl(0, 100, 100, 150);

                // Draw the gradient on the rectangle
                canvas.DrawRect(rect, paint);
            }
        }


        public static readonly BindableProperty TextProperty =
        BindableProperty.Create("Text", typeof(string), typeof(AnimatedButton), null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleTextChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void HandleTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //var obj = bindable as AnimatedButton;
            //obj.Text = (string)newValue;
        }

        public static readonly BindableProperty IconProperty =
        BindableProperty.Create("Icon", typeof(string), typeof(AnimatedButton), defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleIconChanged);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        private static void HandleIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as AnimatedButton;
            obj.Icon = (string)newValue;
        }

        public static readonly BindableProperty _xProperty =
        BindableProperty.Create("_x", typeof(string), typeof(AnimatedButton), defaultBindingMode: BindingMode.TwoWay, propertyChanged: HandleXChanged);

        public double _x
        {
            get { return Double.Parse((string)GetValue(_xProperty)); }
            set { SetValue(_xProperty, value); }
        }

        private static void HandleXChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as AnimatedButton;
            //obj._x = Double.Parse((string)newValue);
        }

        public static readonly BindableProperty _yProperty =
        BindableProperty.Create("_y", typeof(string), typeof(AnimatedButton), propertyChanged: HandleYChanged);

        public double _y
        {
            get { return Double.Parse((string)GetValue(_yProperty)); }
            set { SetValue(_yProperty, value); }
        }

        private static void HandleYChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as AnimatedButton;
            //obj._y = Double.Parse((string)newValue);
        }

        public static readonly BindableProperty imageProperty =
        BindableProperty.Create("image", typeof(string), typeof(AnimatedButton), propertyChanged: HandleImageChanged);

        public string image
        {
            get { return (string)GetValue(imageProperty); }
            set { SetValue(imageProperty, value); }
        }

        private static void HandleImageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var obj = bindable as AnimatedButton;
            obj.image = (string)newValue;
        }


        public AnimatedButton()
        {
            //var tempList = (new NearPlacesViewModel()).Items; /* TO DO */
            if(tempList == null)
            {
                AnimatedButton.tempList = (new NearPlacesViewModel()).Items;
            }
            var currentListItem = tempList[counter];
            if(counter < tempList.Count) counter++;
            double distDouble = Math.Sqrt(Math.Pow((currentListItem.x - MapPage.lastKnownLocation.Latitude), 2) + Math.Pow((currentListItem.y - MapPage.lastKnownLocation.Longitude), 2));
            //string distance = distDouble.ToString();
            string distance = "";
            string time = (distDouble / 84).ToString();
            //distance += "м, ";
            //distance += time;
            //distance += "мин";
            string text = currentListItem.name, img = "Back.jpg";
            string icon = "eventPlace.png";
            if(currentListItem.type == 1)
            {
                icon = "park.png";
            }
            else if(currentListItem.type == 2)
            {
                icon = "monument.png";
            }
            else if(currentListItem.type == 3)
            {
                icon = "culture.png";
            }
            var mainPage = App.mainPage as MainPage;
            Action callback = () => { mainPage.ChangeTab(1, currentListItem.x, currentListItem.y); };
            int imageSize = (Screen.ScreenHeight - Screen.TabSize) / 7;
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Image _image = new Image() { VerticalOptions = LayoutOptions.FillAndExpand, Aspect = Aspect.AspectFill, Margin = new Thickness(0, 0, 0, 0), HorizontalOptions = LayoutOptions.FillAndExpand, HeightRequest = imageSize };
            _image.Source = new FileImageSource() { File = img };
            // create the layout

            _grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            _layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = 5,
            };
            // create the label
            if (icon != "")
            {
                _icon = new Image
                {
                    Source = icon,
                    HeightRequest = 60,
                    WidthRequest = 75,
                    Margin = new Thickness(15, 0, 0, 0),
                    VerticalOptions = LayoutOptions.Center
                };
            }
            else
            {
                _icon = new Image
                { };
            }

            _StackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _textLabel1 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                Text = text,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                XAlign = TextAlignment.Start
            };

            _textLabel2 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                Text = distance,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                XAlign = TextAlignment.Start
            };

            _StackLayout.Children.Add(_textLabel1);
            if (distance != "")
            {
                _StackLayout.Children.Add(_textLabel2);
            }

            _layout.Children.Add(_icon);
            _layout.Children.Add(_StackLayout);

            _grid.Children.Add(_image);
            _grid.Children.Add(canvasView);
            _grid.Children.Add(_layout);

            _result = new Frame() { CornerRadius = 20, Content = _grid, BorderColor = Color.Silver, Padding = 0, HasShadow = true, IsClippedToBounds = true };

            // add a gester reco
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async (o) =>
                {
                    //this.IsEnabled = false;
                    await this.ScaleTo(0.95, 50, Easing.CubicOut);
                    await this.ScaleTo(1, 50, Easing.CubicIn);
                    if (callback != null)
                    {
                        callback.Invoke();
                    }
                })
            });

            // set the content
            this.Content = _result;
        }

        public AnimatedButton(string text, string icon, string description, string img = "monument_background.jpg", Action callback = null)
        {
            int imageSize = (Screen.ScreenHeight - Screen.TabSize) / 5;
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Image _image = new Image() { VerticalOptions = LayoutOptions.FillAndExpand, Aspect = Aspect.AspectFill, Margin = new Thickness(0, 0, 0, 0), HorizontalOptions = LayoutOptions.FillAndExpand, HeightRequest = imageSize };
            _image.Source = new FileImageSource() { File = img };
            // create the layout
            _grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            _layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = 5,
            };
            // create the label
            if (icon != "")
            {
                _icon = new Image
                {
                    Source = icon,
                    HeightRequest = 60,
                    WidthRequest = 75,
                    Margin = new Thickness(15, 0, 0, 0),
                    VerticalOptions = LayoutOptions.Center
                };
            }
            else
            {
                _icon = new Image
                { };
            }

            _StackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _textLabel1 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                Text = text,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                XAlign = TextAlignment.Start
            };

            _textLabel2 = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                Text = description,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                XAlign = TextAlignment.Start
            };

            _StackLayout.Children.Add(_textLabel1);
            _StackLayout.Children.Add(_textLabel2);

            _layout.Children.Add(_icon);
            _layout.Children.Add(_StackLayout);

            _grid.Children.Add(_image);
            _grid.Children.Add(canvasView);
            _grid.Children.Add(_layout);

            _result = new Frame() { CornerRadius = 20, Content = _grid, BorderColor = Color.Silver, Padding = 0, HasShadow = true, IsClippedToBounds = true };

            // add a gester reco
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async (o) =>
                {
                    //this.IsEnabled = false;
                    await this.ScaleTo(0.95, 50, Easing.CubicOut);
                    await this.ScaleTo(1, 50, Easing.CubicIn);
                    if (callback != null)
                    {
                        callback.Invoke();
                    }
                })
            });

            // set the content
            this.Content = _result;
        }

        /// <summary>
        /// Gets or sets the font size for the text
        /// </summary>
        public virtual double FontSize
        {
            get { return this._textLabel1.FontSize; }
            set
            {
                this._textLabel1.FontSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the text color for the text
        /// </summary>
        public virtual Color TextColor
        {
            get
            {
                return _textLabel1.TextColor;
            }
            set
            {
                _textLabel1.TextColor = value;
            }
        }
    }
}

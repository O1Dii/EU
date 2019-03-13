using EUGamesApp.Models;
using EUGamesApp.ViewModels;
using EUGamesApp.Services;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;



namespace EUGamesApp.Views
{

    public class CarouselViewCell : ViewCell
    {
        public CarouselViewCell()
        {
            var image = new Image
            {
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            image.SetBinding(Image.SourceProperty, "ImageBase64");

            View = image;
        }
    }

    public class MyClass
    { 
        public List<ImageSource> MyDataSource;
        public MyClass()
        {
            MyDataSource = new List<ImageSource>() {
                        new FileImageSource() { File = "First.jpg" },
                        new FileImageSource() { File = "Second.jpg" },
                        new FileImageSource() { File = "Third.jpg" },
                        new FileImageSource() { File = "Fourth.jpg" },
                        new FileImageSource() { File = "Fifth.jpg" },
                        new FileImageSource() { File = "Sixth.jpg" }
                };
        }

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage {


        List<Image> imageList;
        int Count = 0;
        short Counter = 0;
        int SlidePosition = 0;
        public TimetablePage page;

        //        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        //        List<HomeMenuItem> menuItems;
        //        List<HomeMenuItem> lowerMenuItems;
        //        int rowHeight1;
        public DataTemplate GetDataTemplate()
        {
            return new DataTemplate(() =>
            {
                Image v = imageList[Count];
                Count++;
                return v;
            });
        }


        public MenuPage()
        {
            InitializeComponent();

            imageList = new List<Image>();
            imageList.Add(new Image { Source = ImageSource.FromFile("First.jpg"), Aspect = Aspect.AspectFill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand });
            imageList.Add(new Image { Source = ImageSource.FromFile("Second.jpg"), Aspect = Aspect.AspectFill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand });
            imageList.Add(new Image { Source = ImageSource.FromFile("Third.png"), Aspect = Aspect.AspectFill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand });
            imageList.Add(new Image { Source = ImageSource.FromFile("Fourth.png"), Aspect = Aspect.AspectFill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand });
            //imageList.Add(new Image { Source = ImageSource.FromFile("Fifth.png"), Aspect = Aspect.AspectFill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand });
            //imageList.Add(new Image { Source = ImageSource.FromFile("Sixth.png"), Aspect = Aspect.AspectFill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand });
            imageList.Add(new Image { Source = ImageSource.FromFile("First.jpg"), Aspect = Aspect.AspectFill, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand });
            Label eventName = new Label()
            {
                Margin = new Thickness(10, 0, 10, 0),
                Text = "Европейские Игры 2019",
                FontSize = 25,
                TextColor = Color.AntiqueWhite,
                FontFamily = Device.RuntimePlatform == Device.Android ? "Montserrat-SemiBold.ttf#Montserrat-SemiBold" :
                Device.RuntimePlatform == Device.iOS ? "Montserrat-SemiBold" : null,
                FontAttributes = FontAttributes.Italic
            };


            CarouselView cv = new CarouselView {
                ItemsSource = imageList,
                ItemTemplate = GetDataTemplate(),
            };

            Device.StartTimer(TimeSpan.FromSeconds(1.5), () =>
            {
                if (SlidePosition == imageList.Count - 1) {
                    SlidePosition = 0;
                    cv.ScrollTo(SlidePosition, animate: false);
                    //SlidePosition++;
                    //cv.ScrollTo(SlidePosition);               
                }
                else {
                    SlidePosition++;
                    cv.ScrollTo(SlidePosition);
                }
                return true;
            });



            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = ( Screen.ScreenHeight - Screen.TabSize ) / 15 * 6 });
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = ( Screen.ScreenHeight - Screen.TabSize ) / 15 * 7 });
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = ( Screen.ScreenHeight - Screen.TabSize ) / 15 * 2 });
            mainGrid.RowDefinitions.Add(new RowDefinition() { Height = Screen.TabSize });
            SKCanvasView canvasView = new SKCanvasView();
            SKCanvasView canvasReverse = new SKCanvasView();
            SKCanvasView canvasLower = new SKCanvasView();


            //MyClass obj = new MyClass();
            //BindingContext = obj;
            //CarouselView cv = new CarouselView()
            //{
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    Margin = new Thickness(0, 0, 0, 0),
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    ItemTemplate = new DataTemplate(typeof(CarouselViewCell)),
            //};

            _carousel.ItemsSource = new List<ImageSource>() {
                    ImageSource.FromFile("euLogo.png"),
                    ImageSource.FromFile("meme.jpg"),
                    ImageSource.FromFile("euLogo.png")};

            //Image[] mas = {
            //    new Image() { Source = new FileImageSource() { File = "euLogo.png" } },
            //    new Image() { Source = new FileImageSource() { File = "euLogo.png" } },
            //    new Image() { Source = new FileImageSource() { File = "euLogo.png" } },
            //    new Image() { Source = new FileImageSource() { File = "euLogo.png" } }
            //};
            //MainCarouselView.ItemsSource = new List<string> { "euLogo.png", "euLogo.png", "euLogo.png", "euLogo.png" };

            Grid centerGrid = new Grid() { Padding = new Thickness(5, 10, 5, 10), Margin = new Thickness(0, 0, 0, 0), HorizontalOptions = LayoutOptions.FillAndExpand };
            Grid lowerGrid = new Grid() { Padding = new Thickness(5, 10, 5, 5), HorizontalOptions = LayoutOptions.EndAndExpand };
            Image image = new Image() { VerticalOptions = LayoutOptions.FillAndExpand, Aspect=Aspect.AspectFill, Margin = new Thickness(0, 0, 0, 0), HorizontalOptions = LayoutOptions.FillAndExpand };
            mainGrid.RowSpacing = 0;
            image.Source = new FileImageSource() { File = "euLogo.png" };

            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            canvasReverse.PaintSurface += OnCanvasViewPaintSurfaceOpposite;
            canvasLower.PaintSurface += OnCanvasViewPaintSurfaceLower;

            RelativeLayout rl = new RelativeLayout()
            {
                BackgroundColor = Color.Red,
                //HeightRequest = 120,
                Padding = new Thickness( 0, 0, 0, 0 ),
                Margin = new Thickness(0, 0, 0, 0)
            };
            rl.Children.Add(cv,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((mainGrid) => { return mainGrid.Width; }),
                ////Constraint.Constant(70),
                Constraint.RelativeToParent((mainGrid) => { return (Screen.ScreenHeight - Screen.TabSize) / 15 * 6; })
            );
;           rl.Children.Add(canvasView,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((mainGrid) => { return mainGrid.Width; }),
                Constraint.RelativeToParent((mainGrid) => { return (Screen.ScreenHeight - Screen.TabSize ) / 15 * 6 ; })
            );
            rl.Children.Add(canvasReverse,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((mainGrid) => { return mainGrid.Width; }),
                Constraint.RelativeToParent((mainGrid) => { return (Screen.ScreenHeight - Screen.TabSize) / 15 * 6; })
            );
            rl.Children.Add(eventName, 
                Constraint.Constant(0),
                Constraint.Constant(0));
            //mainGrid.Children.Add(image, 0, 0);
            //mainGrid.Children.Add(canvasView, 0, 0);           

            //centerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = Screen.ScreenWidth - 10 });
            page = new TimetablePage((MainPage)App.getMainPage());
            centerGrid.Children.Add(new AnimatedButton("Расписание", "", "", "timetable_background.jpg", async () => {
                await Navigation.PushModalAsync(new NavigationPage(page));
            }), 0, 0);
            centerGrid.Children.Add(new AnimatedButton("Медальный зачёт", "", "", "medals_background.jpg", async () => {
                await Navigation.PushModalAsync(new NavigationPage(new MedalsPage()));
            }), 0, 1);
            centerGrid.Children.Add(new AnimatedButton("О Минске", "", "", "minsk_background.jpg", async () => {
                var masterPage = this.Parent as MainPage;
                masterPage.ChangeTab(0);
            }), 0, 2);
            //centerGrid.Children.Add(new AnimatedButton("Ещё что-то", "", "даже не знаю, что здесь будет", "", "useless_background.jpg"), 0, 3);

            lowerGrid.ColumnDefinitions.Add(new ColumnDefinition() { });
            lowerGrid.ColumnDefinitions.Add(new ColumnDefinition() { });
            lowerGrid.Children.Add(new AnimatedButton("О приложении", "", "", "about_background.png", async () => {
                await Navigation.PushModalAsync(new NavigationPage(new AppInfo()));
            }), 0, 0);
            lowerGrid.Children.Add(new AnimatedButton("Настройки", "", "", "settings_background.png", async () => {
                await Navigation.PushModalAsync(new NavigationPage(new Settings()));
            }), 1, 0);

            mainGrid.Children.Add(rl, 0, 0);
            mainGrid.Children.Add(centerGrid, 0, 1);
            mainGrid.Children.Add(canvasLower, 0, 2);
            mainGrid.Children.Add(lowerGrid, 0, 2);
            Content = mainGrid;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                SKRect rect = new SKRect(0, 0, Screen.WidthPixels, 500);

                // Create linear gradient from upper-left to lower-right
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint((rect.Right + rect.Left) / 2, rect.Top),
                                    new SKPoint((rect.Right + rect.Left) / 2, rect.Bottom),
                                    new SKColor[] { SKColors.Black, SKColors.Transparent },
                                    new float[] { 0, 1 },
                                    SKShaderTileMode.Repeat);

                // Draw the gradient on the rectangle
                canvas.DrawRect(rect, paint);
            }
        }

        void OnCanvasViewPaintSurfaceOpposite(object sender, SKPaintSurfaceEventArgs args)
        {

            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                SKRect rect = new SKRect(0, (Screen.HeightPrixels - Screen.TabSizePixels) / 15 * 6 - 50, Screen.WidthPixels, (Screen.HeightPrixels - Screen.TabSizePixels) / 15 * 6);

                // Create linear gradient from upper-left to lower-right
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint((rect.Right + rect.Left) / 2, rect.Bottom),
                                    new SKPoint((rect.Right + rect.Left) / 2, rect.Top),
                                    new SKColor[] { SKColors.Black, SKColors.Transparent },
                                    new float[] { 0, 1 },
                                    SKShaderTileMode.Repeat);

                // Draw the gradient on the rectangle
                canvas.DrawRect(rect, paint);
            }
        }


        void OnCanvasViewPaintSurfaceLower(object sender, SKPaintSurfaceEventArgs args)
        {

            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                SKRect rect = new SKRect(0, 0, Screen.WidthPixels, 50);

                // Create linear gradient from upper-left to lower-right
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint((rect.Right + rect.Left) / 2, rect.Top),
                                    new SKPoint((rect.Right + rect.Left) / 2, rect.Bottom),
                                    new SKColor[] { SKColors.Black, SKColors.Transparent },
                                    new float[] { 0, 1 },
                                    SKShaderTileMode.Repeat);

                // Draw the gradient on the rectangle
                canvas.DrawRect(rect, paint);
            }
        }

        private async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Settings()));
        }

        private async void Event_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}
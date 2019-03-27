namespace EUGamesApp.Views
{
	using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using EUGamesApp.Services;
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    //using Xamarin.Forms.Maps;
    using Xamarin.Forms.GoogleMaps;
    using System.Collections.Generic;
    using EUGamesApp.Models;
    using Plugin.Toast;
    using EUGamesApp.ViewModels;
    using System.ComponentModel;
    using Xamarin.Forms.PlatformConfiguration;
    using Xamarin.Essentials;
    using Plugin.Geolocator;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage, INotifyPropertyChanged
    {
        private RelativeLayout _layout;
        private Xamarin.Forms.GoogleMaps.Map GoogleMap;
        private StackLayout map_layout;
        public static Plugin.Geolocator.Abstractions.Position lastKnownLocation;

        private Plugin.Geolocator.Abstractions.IGeolocator geolocator;
        private Circle circle;
        private bool customPoint;
        public static bool isMainPlacesTurnedOn;
        private Dictionary<string, List<Pin>> points;
        public static List<Pin> nearbyPins { get; set; }

        private double averageManSpeed; //meters per minute

        private double defaultZoom;

        //public static List<Pin> getNearbyPlaces()
        //{
        //    nearbyPins = new List<Pin>();
        //    return
        //}
        static MapPage()
        {
            //isMainPlacesTurnedOn = true;
            nearbyPins = new List<Pin>();
            lastKnownLocation = new Plugin.Geolocator.Abstractions.Position(53.9017156, 27.5561379);
        }

        public MapPage()
        {
            averageManSpeed = 84;
            customPoint = false;
            defaultZoom = 40;
            points = new Dictionary<string, List<Pin>>();
            // create the layout
            _layout = new RelativeLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            
            GoogleMap = new Xamarin.Forms.GoogleMaps.Map();
            
            GoogleMap.MyLocationEnabled = true;
            GoogleMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(53.9017156, 27.5561379), Distance.FromKilometers(13)));
            GoogleMap.IsIndoorEnabled = true;
            GoogleMap.IsTrafficEnabled = true;
            
            GoogleMap.UiSettings.IndoorLevelPickerEnabled = true;
            GoogleMap.UiSettings.MapToolbarEnabled = true;
            GoogleMap.UiSettings.MyLocationButtonEnabled = true;


            Device.StartTimer(TimeSpan.FromSeconds(15), () =>
            {
                var mainPage = App.getMainPage() as MainPage;
                if (mainPage != null && mainPage.CurrentPage == this)
                {
                    getLocation();
                    GoogleMap.Circles.Clear();
                    if (Setting.radius != 0 && Setting.radius != 40)
                    {
                        
                        //animation.Commit(circle, "Animation", 16, 2000, Easing.Linear, (v, c) => circle.Center = new Position(lastKnownLocation.Latitude, lastKnownLocation.Longitude), () => false);
                        circle = new Circle()
                        {
                            Center = new Position(lastKnownLocation.Latitude, lastKnownLocation.Longitude),
                            Radius = Distance.FromMeters(Setting.radius * averageManSpeed),
                            FillColor = Color.FromHex("#50758191"),
                        };
                        GoogleMap.Circles.Add(circle);
                        reCalculatePins();
                    }
                }
                return true;
            });

            this.Title = AppResources.Map;

            GoogleMap.MyLocationButtonClicked += (sender, e) =>
            {
                GoogleMap.SelectedPin = null;
                getLocation();
                if(GoogleMap.CameraPosition.Zoom < 10)
                {
                    GoogleMap.AnimateCamera(
                    CameraUpdateFactory.NewPositionZoom(new Position(lastKnownLocation.Latitude, lastKnownLocation.Longitude), defaultZoom));
                }
                else
                {
                    GoogleMap.AnimateCamera(
                    CameraUpdateFactory.NewPosition(new Position(lastKnownLocation.Latitude, lastKnownLocation.Longitude)));
                }
                
            };

            GoogleMap.MapLongClicked += (sender, e) =>
            {
                if (customPoint)
                {
                   GoogleMap.Pins.RemoveAt(0);
                }
                GoogleMap.Pins.Insert(0,
                    new Pin()
                    {
                        Type = PinType.SavedPin,
                        Position = e.Point,
                        Label = e.Point.Latitude.ToString() + ", " + e.Point.Longitude.ToString(),
                        ZIndex = 100
                    });
                customPoint = true;
                GoogleMap.AnimateCamera(
                    CameraUpdateFactory.NewPosition(e.Point));
            };

            GoogleMap.MapClicked += (sender, e) =>
            {
                if (customPoint)
                {
                    GoogleMap.Pins.RemoveAt(0);
                    customPoint = false;
                }
                GoogleMap.SelectedPin = null;
            };

            GoogleMap.InfoWindowClicked += PinClicked;

            
            points.Add("MainPlaces", new List<Pin>(
                EventsViewModel.places.Select(
                    x => new Pin()
                    {
                        Type = PinType.Place,
                        Position = new Position(x.x, x.y),
                        Label = x.name,
                        Address = x.address,
                        ZIndex = 10,
                        IsVisible = false,
                    }
                    )).ToList()
            );

            points.Add("TempPlaces", new List<Pin>(
                EventsViewModel.tempPlaces.Select(
                    x => new Pin()
                    {
                        Type = PinType.Place,
                        Position = new Position(x.x, x.y),
                        Label = x.name,
                        Address = x.address,
                        ZIndex = 1,
                        IsVisible = false,
                    }
                    )).ToList()
            );

            points.Add("DebugPlaces", new List<Pin>(){
                new Pin() {
                    Type = PinType.Place,
                    Position = new Position(53.8488890958488, 27.4577881023288),
                    Label = "1",
                    Address = "1",
                    ZIndex = 10,
                    IsVisible = false,
                },
                new Pin() {
                    Type = PinType.Place,
                    Position = new Position(53.8464048418932, 27.4624742567539),
                    Label = "1",
                    Address = "1",
                    ZIndex = 10,
                    IsVisible = false,
                }
            });
            //addPins(points["DebugPlaces"]);

            //addPins(points["TempPlaces"]);


            map_layout = new StackLayout();
            map_layout.BindingContext = GoogleMap;
            map_layout.Children.Add(GoogleMap);
            
            CreateMap();
            this.Content = _layout;
            addPins();
        }

        public void reCalculatePins()
        {
            points["MainPlaces"].ForEach(x => x.IsVisible = isMainPlacesTurnedOn);
            if (Setting.radius == 40)
            {
                addPins(true);
            }
            else if (Setting.radius != 0)
            {
                getLocation();
                double distance;
                double radiusToShow = Setting.radius * averageManSpeed;
                foreach (var title in isMainPlacesTurnedOn ? points.Keys.Skip(1) : points.Keys)
                {
                    points[title].ForEach(
                        x => {
                            distance = Location.CalculateDistance(x.Position.Latitude, x.Position.Longitude,
                         lastKnownLocation.Latitude, lastKnownLocation.Longitude, DistanceUnits.Kilometers) * 1000;
                            x.IsVisible = distance <= radiusToShow ? true : false;
                        }
                        );
                }
                addPins();
            }
            else
            {
                if(isMainPlacesTurnedOn) {
                    addPins();
                }
            }
        }

        public void addPins(bool all = false, List<Pin> listToAdd = null)
        {
            GoogleMap.Pins.Clear();
            nearbyPins.Clear();
            if (listToAdd != null)
            {
                foreach (var elem in listToAdd)
                {
                    elem.IsVisible = true;
                    GoogleMap.Pins.Add(elem);
                    nearbyPins.Add(elem);
                }
            }
            if (Setting.radius != 0)
            {
                if (all)
                {
                    foreach (var elemD in points.Values)
                    {
                        foreach (var item in elemD)
                        {
                            item.IsVisible = true;        
                            GoogleMap.Pins.Add(item);
                            nearbyPins.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (var elemD in points.Values)
                    {
                        foreach (var item in elemD.Where(x => x.IsVisible))
                        {
                            GoogleMap.Pins.Add(item);
                            nearbyPins.Add(item);
                        }
                    }
                }
            }
            else if(isMainPlacesTurnedOn)
            {
                points["MainPlaces"].ForEach(GoogleMap.Pins.Add);
                points["MainPlaces"].ForEach(nearbyPins.Add);
            }
        }


        private async void getLocation()
        {
            geolocator = CrossGeolocator.Current;
            geolocator.DesiredAccuracy = 5;
            
            lastKnownLocation = await geolocator.GetPositionAsync(TimeSpan.FromMilliseconds(10));
        }

        private void CreateMap()
        {
            _layout.Children.Add(map_layout,
                    Constraint.RelativeToParent((p) =>
                    {
                        return 0;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return 0;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Width - 2;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height;
                    }));
        }

        private void PinClicked(object sender, EventArgs eventArgs)
        {
            var selectedPin = sender as Pin;
            
            DisplayAlert(selectedPin?.Label, selectedPin?.Address, "Ok");
        }

        public void ZoomToPoint(double latitude, double longitude)
        {
            Position pos = new Position(latitude, longitude);
            IList<Pin> list = GoogleMap.Pins;
            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            try
            {
                while (enumerator.Current.Position != pos)
                {
                    enumerator.MoveNext();
                }
            }
            catch {
                GoogleMap.MoveCamera(CameraUpdateFactory.NewCameraPosition(new CameraPosition(pos, 15f)));
                return;
            }
            GoogleMap.MoveCamera(CameraUpdateFactory.NewCameraPosition(new CameraPosition(pos, 15f)));
            if (enumerator.Current.Position == pos)
            {
                GoogleMap.SelectedPin = enumerator.Current;
            }
        }


        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //}

        public int getTabbarSize()
        {
            return (int)(Models.Screen.HeightPrixels - GoogleMap.MinimumHeightRequest);
        }
    }
}
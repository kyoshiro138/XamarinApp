using System;
using Xamarin.Core;
using System.Threading.Tasks;

namespace App.Shared
{
    public class PlaceInfoScreenLogic
    {
        private IPlaceInfoScreen placeInfoScreen;

        public PlaceInfoScreenLogic(IPlaceInfoScreen screen)
        {
            placeInfoScreen = screen;
        }

        public async Task InitializeScreen(TravelPlace travelPlace)
        {
            IButton btnLocations = placeInfoScreen.GetControlByTag(PlaceInfoScreenConst.ControlButtonLocations) as IButton;
            btnLocations.Text = PlaceInfoScreenConst.StringButtonLocations;

            if (travelPlace != null)
            {
                IUrlImageView ivPlaceCover = placeInfoScreen.GetControlByTag(PlaceInfoScreenConst.ControlImagePlaceCover) as IUrlImageView;
                ILabel lblPlaceName = placeInfoScreen.GetControlByTag(PlaceInfoScreenConst.ControlLabelPlaceName) as ILabel;
                ILabel lblPlaceSubname = placeInfoScreen.GetControlByTag(PlaceInfoScreenConst.ControlLabelPlaceSubname) as ILabel;
                ILabel lblPlaceDescription = placeInfoScreen.GetControlByTag(PlaceInfoScreenConst.ControlLabelPlaceDescription) as ILabel;
                ILabel lblPlaceRating = placeInfoScreen.GetControlByTag(PlaceInfoScreenConst.ControlLabelPlaceRating) as ILabel;
                ILabel lblTravelerCount = placeInfoScreen.GetControlByTag(PlaceInfoScreenConst.ControlLabelTravelerCount) as ILabel;

                ivPlaceCover.LoadImageFromUrl(travelPlace.PlaceCoverUrl);
                lblPlaceName.Text = travelPlace.PlaceName;
                lblPlaceDescription.Text = travelPlace.PlaceDescription;
                lblPlaceRating.Text = string.Format("({0})", travelPlace.PlaceRating);
                lblTravelerCount.Text = "0";

                var country = await placeInfoScreen.TravelManager.GetLocalCountry(travelPlace.CountryId);
                if (country != null && !string.IsNullOrEmpty(country.CountryName))
                {
                    lblPlaceSubname.IsVisible = true;
                    lblPlaceSubname.Text = country.CountryName;    
                }
                else
                {
                    lblPlaceSubname.IsVisible = false;
                    lblPlaceSubname.Text = "";
                }
            }
        }

        public void HandleButtonLocationsClicked(TravelPlace data, IScreen screen)
        {
            placeInfoScreen.Navigator.NavigateTo<TravelPlace>(screen, data, HomeScreenConst.ParamLocationList);
        }
    }
}


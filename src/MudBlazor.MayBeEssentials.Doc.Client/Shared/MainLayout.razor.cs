using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MudBlazor.MayBeEssentials.Doc.Client.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {

        [Inject] private NavigationManager NavigationManager { get; set; }

        bool _drawerOpen = true;

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        MudTheme MyCustomTheme = new MudTheme()
        {
            Palette = new Palette()
            {
                Primary = Colors.Blue.Default,
                Secondary = Colors.Indigo.Default,
                AppbarBackground = "#9A1720"
                // Secondary = Colors.Green.Accent4,
            }
        };



        protected override void OnInitialized()
        {
            _currentTheme = _defaultTheme;
        }



        private void OnSwipe(SwipeDirection direction)
        {
            if (direction == SwipeDirection.LeftToRight && !_drawerOpen)
            {
                _drawerOpen = true;
                StateHasChanged();
            }
            else if (direction == SwipeDirection.RightToLeft && _drawerOpen)
            {
                _drawerOpen = false;
                StateHasChanged();
            }
        }

        #region Theme        

        private void SwitchToServer()
        {
            NavigationManager.NavigateTo(NavigationManager.Uri.Replace("wasm/", string.Empty), forceLoad: true);
        }

        private void SwitchToWasm()
        {
            NavigationManager.NavigateTo(NavigationManager.Uri.Replace(
                NavigationManager.BaseUri,
                NavigationManager.BaseUri + "wasm/" + NavigationManager.ToBaseRelativePath(NavigationManager.BaseUri))
                , forceLoad: true);
        }

        private bool Wasm => NavigationManager.Uri.Contains("wasm");

        private void DarkMode()
        {
            if (_currentTheme == _defaultTheme)
            {
                _currentTheme = _darkTheme;
            }
            else
            {
                _currentTheme = _defaultTheme;
            }
        }

        private MudTheme _currentTheme = new MudTheme();
        private readonly MudTheme _defaultTheme =
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Black = "#272c34"
                }
            };
        private readonly MudTheme _darkTheme =
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Black = "#27272f",
                    Background = "#32333d",
                    BackgroundGrey = "#27272f",
                    Surface = "#373740",
                    DrawerBackground = "#27272f",
                    DrawerText = "rgba(255,255,255, 0.50)",
                    AppbarBackground = "#27272f",
                    AppbarText = "rgba(255,255,255, 0.70)",
                    TextPrimary = "rgba(255,255,255, 0.70)",
                    TextSecondary = "rgba(255,255,255, 0.50)",
                    ActionDefault = "#adadb1",
                    ActionDisabled = "rgba(255,255,255, 0.26)",
                    ActionDisabledBackground = "rgba(255,255,255, 0.12)",
                    DrawerIcon = "rgba(255,255,255, 0.50)"
                }
            };

        #endregion
    }
}

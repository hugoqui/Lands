using System;
using Lands.Models;

namespace Lands.ViewModels
{
    public class LandViewModel
    {
        #region Props
        public Land Land { get; set; }
        #endregion

        #region Constr
        public LandViewModel(Land land)
        {
            Land = land;
        }
        #endregion
    }
}

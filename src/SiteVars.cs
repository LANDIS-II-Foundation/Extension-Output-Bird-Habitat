using Landis.SpatialModeling;
using Landis.Library.UniversalCohorts;
using System.Collections.Generic;

namespace Landis.Extension.Output.LandscapeHabitat
{
    public static class SiteVars
    {
        private static ISiteVar<SiteCohorts> cohorts;
        private static ISiteVar<Dictionary<string,int>> localVars;
        private static ISiteVar<Dictionary<string, float>> derivedVars;
        private static ISiteVar<Dictionary<string, float>> neighborVars;
        private static ISiteVar<Dictionary<string, float>> climateVars;
        private static ISiteVar<Dictionary<string, float>> distanceVars;
        private static ISiteVar<Dictionary<string, float>> speciesModels;
        
        //---------------------------------------------------------------------

        public static void Initialize()
        {
            cohorts = PlugIn.ModelCore.GetSiteVar<SiteCohorts>("Succession.UniversalCohorts");

            if (cohorts == null)
            {
                string mesg = string.Format("Cohorts are empty.  Please double-check that this extension is compatible with your chosen succession extension.");
                throw new System.ApplicationException(mesg);
            }
            localVars = PlugIn.ModelCore.Landscape.NewSiteVar<Dictionary<string, int>>();
            derivedVars = PlugIn.ModelCore.Landscape.NewSiteVar<Dictionary<string, float>>();
            neighborVars = PlugIn.ModelCore.Landscape.NewSiteVar<Dictionary<string, float>>();
            climateVars = PlugIn.ModelCore.Landscape.NewSiteVar<Dictionary<string, float>>();
            distanceVars = PlugIn.ModelCore.Landscape.NewSiteVar<Dictionary<string, float>>();
            speciesModels = PlugIn.ModelCore.Landscape.NewSiteVar<Dictionary<string, float>>();

            foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
            {
                SiteVars.LocalVars[site] = new Dictionary<string, int>();
                SiteVars.DerivedVars[site] = new Dictionary<string, float>();
                SiteVars.NeighborVars[site] = new Dictionary<string, float>();
                SiteVars.ClimateVars[site] = new Dictionary<string, float>();
                SiteVars.DistanceVars[site] = new Dictionary<string, float>();
                SiteVars.SpeciesModels[site] = new Dictionary<string, float>();
            }
        }

        //---------------------------------------------------------------------
        public static ISiteVar<SiteCohorts> Cohorts
        {
            get
            {
                return cohorts;
            }
        }
        //---------------------------------------------------------------------
        public static ISiteVar<Dictionary<string, int>> LocalVars
        {
            get
            {
                return localVars;
            }
        }
        //---------------------------------------------------------------------
        public static ISiteVar<Dictionary<string, float>> DerivedVars
        {
            get
            {
                return derivedVars;
            }
        }
        //---------------------------------------------------------------------
        public static ISiteVar<Dictionary<string, float>> NeighborVars
        {
            get
            {
                return neighborVars;
            }
        }
        //---------------------------------------------------------------------
        public static ISiteVar<Dictionary<string, float>> ClimateVars
        {
            get
            {
                return climateVars;
            }
        }
        //---------------------------------------------------------------------
        public static ISiteVar<Dictionary<string, float>> DistanceVars
        {
            get
            {
                return distanceVars;
            }
        }
        //---------------------------------------------------------------------
        public static ISiteVar<Dictionary<string, float>> SpeciesModels
        {
            get
            {
                return speciesModels;
            }
        }
    }
}

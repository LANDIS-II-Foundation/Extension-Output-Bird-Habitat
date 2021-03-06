//  Copyright 2005-2010 Portland State University, University of Wisconsin-Madison
//  Authors:  Robert M. Scheller, Jimm Domingo

using System.Collections.Generic;
using System.Data;

namespace Landis.Extension.Output.LandscapeHabitat
{
    /// <summary>
    /// The parameters for the plug-in.
    /// </summary>
    public interface IInputParameters
    {
        /// <summary>
        /// Timestep (years)
        /// </summary>
        int Timestep
        {
            get;set;
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Reclass maps
        /// </summary>
        List<IMapDefinition> ReclassMaps
        {
            get;
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// DerivedVars
        /// </summary>
        List<IVariableDefinition> DerivedVars
        {
            get;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// NeighborVars
        /// </summary>
        List<INeighborVariableDefinition> NeighborVars
        {
            get;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// ClimateVars
        /// </summary>
        List<IClimateVariableDefinition> ClimateVars
        {
            get;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// NeighborVars
        /// </summary>
        List<IDistanceVariableDefinition> DistanceVars
        {
            get;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Models
        /// </summary>
        List<IModelDefinition> Models
        {
            get;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for reclass maps.
        /// </summary>
        string LocalVarMapFileNames
        {
            get;set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for reclass maps.
        /// </summary>
        string NeighborMapFileNames
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for reclass maps.
        /// </summary>
        string ClimateMapFileNames
        {
            get;
            set;
        }
        //---------------------------------------------------------------------        
        /// <summary>
        /// Template for the filenames for Distance variable maps.
        /// </summary>
        string DistanceMapFileNames
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for species output maps.
        /// </summary>
        string SpeciesMapFileNames
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Climate data table.
        /// </summary>
        DataTable ClimateDataTable
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Log file name.
        /// </summary>
        string LogFileName { get; set; }
        //---------------------------------------------------------------------
        /// <summary>
        /// Template for the filenames for species output logs.
        /// </summary>
        string SpeciesLogFileNames
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
    }
}

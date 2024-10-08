//  Authors:  Robert M. Scheller, Jimm Domingo

using Landis.Utilities;
using Landis.Library.Climate;
using System.Data;
using System;

namespace Landis.Extension.Output.LandscapeHabitat
{
    /// <summary>
    /// The definition of a reclass map.
    /// </summary>
    public interface IClimateVariableDefinition
    {
        /// <summary>
        /// Var name
        /// </summary>
        string Name
        {
            get;
            set;
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Climate Library Variable
        /// </summary>
        string ClimateLibVariable
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Source Name
        /// </summary>
        string SourceName
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Year
        /// </summary>
        string Year
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Min Month
        /// </summary>
        int MinMonth
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Max Month
        /// </summary>
        int MaxMonth
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Climate Data
        /// </summary>
        AnnualClimate ClimateData
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Transformation
        /// </summary>
        string Transform
        {
            get;
            set;
        }
        //---------------------------------------------------------------------
    }

    /// <summary>
    /// The definition of a reclass map.
    /// </summary>
    public class ClimateVariableDefinition
        : IClimateVariableDefinition
    {
        private string name;
        private string climateLibVariable;
        private string sourceName;
        private string year;
        private int minMonth;
        private int maxMonth;
        private AnnualClimate climateData;
        private string transform;
        //---------------------------------------------------------------------

        /// <summary>
        /// Var name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Climate Library Variable
        /// </summary>
        public string ClimateLibVariable
        {
            get
            {
                return climateLibVariable;
            }
            set
            {
                climateLibVariable = value;
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Source Name
        /// </summary>
        public string SourceName
        {
            get
            {
                return sourceName;
            }
            set
            {
                sourceName = value;
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Year
        /// </summary>
        public string Year
        {
            get
            {
                return year;
            }
            set
            {
                if ((value.Equals("current", StringComparison.OrdinalIgnoreCase)) || (value.Equals("prev", StringComparison.OrdinalIgnoreCase)))
                    year = value;
                else
                {
                    throw new InputValueException(value.ToString(), "Value must be 'current' or 'prev'.");
                }
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Min Month
        /// </summary>
        public int MinMonth
        {
            get
            {
                return minMonth;
            }
            set
            {
                if ((value < 1) || (value > 12))
                    throw new InputValueException(value.ToString(), "Value must be >=1 and <= 12.");
                minMonth = value;
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Max Month
        /// </summary>
        public int MaxMonth
        {
            get
            {
                return maxMonth;
            }
            set
            {
                if ((value < 1) || (value > 12))
                    throw new InputValueException(value.ToString(), "Value must be >=1 and <= 12.");
                if (value < minMonth)
                    throw new InputValueException(value.ToString(), "Value must be <= MinMonth.");
                maxMonth = value;
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Climate Data
        /// </summary>
        public AnnualClimate ClimateData
        {
            get
            {
                return climateData;
            }
            set
            {
                climateData = value;
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Transformation
        /// </summary>
        public string Transform
        {
            get
            {
                return transform;
            }
            set
            {
                if ((value.Equals("none", StringComparison.OrdinalIgnoreCase)) || (value.Equals("log10", StringComparison.OrdinalIgnoreCase)) || (value.Equals("ln", StringComparison.OrdinalIgnoreCase)))
                    transform = value;
                else
                {
                    throw new InputValueException(value.ToString(), "Value must be 'none', 'log10' or 'ln'.");
                }
            }
        }

        //---------------------------------------------------------------------

        /// <summary>
        /// Initialize a new instance.
        /// </summary>
        public ClimateVariableDefinition()
        {
        }
        //---------------------------------------------------------------------

        public static DataTable ReadWeatherFile(string path)
        {
            PlugIn.ModelCore.UI.WriteLine("   Loading Climate Data...");

            CSVParser weatherParser = new CSVParser();

            DataTable weatherTable = weatherParser.ParseToDataTable(path);

            return weatherTable;
        }
        //---------------------------------------------------------------------
    }
}
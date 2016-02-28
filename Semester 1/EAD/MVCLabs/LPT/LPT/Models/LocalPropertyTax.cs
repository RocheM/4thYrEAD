// model classes for a property value band, the bands for the LPT, and a property and its LPT charge

using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPT.Models
{
    // property value band
    public class PVBand
    {
        public int Min { get; set; }            // inclusive lower limit for band
        public int Max { get; set; }            // inclusive upper limit for band
        
        // midpoint in a band at which property is valued to LPT
        public int MidPoint
        {
            get                                 
            {
                return Min + ((Max - Min) / 2);             // integer division
            }
        }
    }

    // property value tax bands for LPT
    public class PVBands
    {
        public static List<PVBand> bands = new List<PVBand>() 
                                            {
                                                new PVBand(){ Min = 0, Max = 100000},
                                                new PVBand(){ Min = 100001, Max = 150000},
                                                new PVBand(){ Min = 150001, Max = 200000},
                                                new PVBand(){ Min = 200001, Max = 250000},
                                                new PVBand(){ Min = 250001, Max = 300000},
                                                new PVBand(){ Min = 300001, Max = 350000},
                                                new PVBand(){ Min = 350001, Max = 400000},
                                                new PVBand(){ Min = 400001, Max = 450000},
                                                new PVBand(){ Min = 450001, Max = 500000},
                                            };

        // calc the property band for a specified property value
        public static PVBand CalculateBand(int propertyValue)
        {
            PVBand band = bands.FirstOrDefault(b => ((propertyValue >= b.Min) && (propertyValue <= b.Max)));
            if (band == null)
            {
                throw new ArgumentException("Invalid Property Value");
            }
            return band;
        }

    }

    // property value and corresponding band LPT charge
    public class LocalPropertyTax
    {
        [Required(ErrorMessage = "Property Value Required!")]
        [Range(0, 500000, ErrorMessage = "Invalid Property Value!")]
        [DisplayName("Property Value (€)")]
        public int PropertyValue { get; set; }

        // operation to calculate the propery tax
        [DisplayName("Band")]
        public String PropertyValueBand
        {
            get
            {
                PVBand band = PVBands.CalculateBand(PropertyValue);
                return "€" + band.Min + " - €" + band.Max;
            }
        }

        // operation to calculate the propery tax
        [DisplayName("Local Property Tax (€)")]
        public double PropertyTax
        {
            get
            {
                // read tax rate from service config and convert to a %
                double rate = Double.Parse(RoleEnvironment.GetConfigurationSettingValue("LPTTaxRate")) / 100;

                // get band
                PVBand band = PVBands.CalculateBand(PropertyValue);

                // multiply rate by mid point of band
                return rate * band.MidPoint;
            }
        }
    }
}
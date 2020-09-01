using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Asset_Tracking.Add_Assets.add_new_asset
{
    class asset_excel_model
    {
        public String Department;
        public String MachineType;
        public String MachineSubType;
        public String Model;
        public String Brand;
        public String Supplier;
        public String IGPDate;
        public String Price;
        public String Vendor;
        public String YearOfManufactoring;
        public String InstallationDate;
        public String Module;
        public String machine_id ;
        public String SerialNumber;
        public String CountryOfOrigin;
        public String floor;
        public String RFIDTag;

        public asset_excel_model(string department, string machineType, string machineSubType, string model, string brand, string supplier, string iGPDate, string price, string vendor, string yearOfManufactoring, string installationDate, string module, string machine_id, string serialNumber, string countryOfOrigin, string floor, string rFIDTag)
        {
            Department = department;
            MachineType = machineType;
            MachineSubType = machineSubType;
            Model = model;
            Brand = brand;
            Supplier = supplier;
            IGPDate = iGPDate;
            Price = price;
            Vendor = vendor;
            YearOfManufactoring = yearOfManufactoring;
            InstallationDate = installationDate;
            Module = module;
            this.machine_id = machine_id;
            SerialNumber = serialNumber;
            CountryOfOrigin = countryOfOrigin;
            this.floor = floor;
            RFIDTag = rFIDTag;
        }
    }
}

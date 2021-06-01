using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Http
{
    class api_files
    {
        // Software login
        public static String login = "includes/userLogin.php";
        //Warehouse PHP API
        public static String upload_excel_file = "warehouse/insertPackingList.php";
        public static String get_warehouse_orders = "warehouse/getOrdersList.php";
        public static String get_dates = "warehouse/getUploadDates.php";
        public static String get_dcn_for_dates = "warehouse/getDCNForDate.php";
        public static String get_orders_for_dcn_date = "warehouse/getOrdersForDateDCN.php";
        public static String get_packing_list_for_order = "warehouse/getPackingList_forOrderDateDCN.php";
        public static String get_rolls_list_for_order_IN = "warehouse/getRollsListForOrder_IN.php";
        public static String get_rolls_list_for_order_OUT = "warehouse/getRollsListForOrder_OUT.php";
        public static String generate_rfid_for_roll = "warehouse/generateRFID.php";
        public static String assign_rfid_to_roll = "warehouse/assignTagtoRoll.php";
        public static String stock_in = "warehouse/insertRFIDTags.php";
        public static String stock_out = "warehouse/insertRFIDTags.php";
        public static String insert_assign_tag = "warehouse/insertAssignTag.php";
        public static String departmental_stock_summary = "warehouse/getDepartmentalStockSummary.php";
        public static String stock_Out_summary = "warehouse/getDepartmentalProcessingSummary.php";       
        //For Warehouse Departmental Allocation
        public static String for_issuance_get_orders_for_fabric_roll_search = "warehouse/Fabric_roll_search/getOrdersList.php";
        public static String for_issuance_get_fabric_lot_for_order = "warehouse/Fabric_roll_search/getFabriclotForOrder.php";
        public static String for_issuance_get_vendor_for_order_and_fabric_lot = "warehouse/Fabric_roll_search/getVendorForOrder.php";
        public static String for_issuance_get_color_for_order_and_fabric_lot_and_vendor = "warehouse/Fabric_roll_search/getColorForOrder.php";
        public static String for_issuance_get_fabric_type_for_order_and_fabric_lot_and_vendor_and_color = "warehouse/Fabric_roll_search/getFabricTypeForOrder.php";
        public static String for_issuance_get_rolls_for_order_and_fabric_lot_and_vendor_and_color_and_fabric_type = "warehouse/Fabric_roll_search/getRollForOrder,fabric_lot,vendor,color,fabric_type.php";
        public static String for_issuance_get_departments = "warehouse/getDepartments.php";
        public static String for_issuance_create_child_roll = "warehouse/createChildRoll.php";
        public static String for_issuance_insert_department_issuance= "warehouse/insertDeptMovement.php";
        public static String change_order_of_roll = "warehouse/changeOrderForRoll.php";
        // For location update
        public static String for_location_update_get_rack = "warehouse/uhf_scanner/update_location/getRacks.php";
        public static String for_location_update_get_locator_for_racks = "warehouse/uhf_scanner/update_location/getLocatorsForRacks.php";
        public static String for_location_update_get_bin_for_rack_locator = "warehouse/uhf_scanner/update_location/getBinForRackLocator.php";
        public static String update_location_of_roll = "warehouse/uhf_scanner/update_location/updateLocationofRollforRackLocatorBin.php";
        //For Roll Return
        public static String for_roll_return_get_rolls = "warehouse/Roll_return/getRollForReturnToWarehouse.php";
        public static String insert_roll_return = "warehouse/Roll_return/insertRollReturn.php";
        //For Warehouse Departmental Consumption
        public static String for_consumption_get_orders_for_fabric_roll_search = "warehouse/consumption/getOrdersList.php";
        public static String for_consumption_get_fabric_lot_for_order = "warehouse/consumption/getFabriclotForOrder.php";
        public static String for_consumption_get_vendor_for_order_and_fabric_lot = "warehouse/consumption/getVendorForOrder.php";
        public static String for_consumption_get_color_for_order_and_fabric_lot_and_vendor = "warehouse/consumption/getColorForOrder.php";
        public static String for_consumption_get_fabric_type_for_order_and_fabric_lot_and_vendor_and_color = "warehouse/consumption/getFabricTypeForOrder.php";
        public static String for_consumption_get_rolls_for_order_and_fabric_lot_and_vendor_and_color_and_fabric_type = "warehouse/consumption/getRollForOrder,fabric_lot,vendor,color,fabric_type.php";
        public static String for_consumption_insert_department_consumption = "warehouse/insertDeptMovement.php";
        //SPTS Warehouse PHP API
        public static String upload_cutreport = "SPTS/insertCutReport.php";
        public static String upload_StyleBulletin = "SPTS/insertStyleBulletin.php";
        public static String get_orders_list_for_transfer = "SPTS/orderTransfer/getAllOrdersListForTransfer.php";
        public static String transfer_orders_for_order_style_article = "SPTS/orderTransfer/orderTransferForOrderStyleArticle.php";
        public static String get_orders_list = "SPTS/getAllOrdersList.php";
        public static String get_style_for_order = "SPTS/getStyleCodesList.php";
        public static String get_article_for_order = "SPTS/getArticlesList.php";
        public static String get_operations_list = "SPTS/getOperationsList.php";
        public static String insert_operation = "SPTS/insertOperation.php";
        public static String get_lines = "SPTS/getLinesList.php";
        public static String insert_worker = "SPTS/insertWorker.php";
        public static String insert_order = "SPTS/insertOrder.php";
        public static String get_workers_list = "SPTS/getWorkersList.php";
        public static String get_style_bulletin_for_order = "SPTS/getStyleBulletinForOrder.php";
        public static String get_cut_report_for_order = "SPTS/getCutReportForOrder.php";
        // for generate packing list
        public static String get_goods_code = "warehouse/getGoodsCodeList.php";
        public static String get_fabric_content = "warehouse/packing_list/getFabricContent.php";
        public static String get_packing_list_for_goods_code = "warehouse/packing_list/getPackingListForGoodsCode.php";
        public static String delete_packing_list = "warehouse/packing_list/deletePackingListForGoodsCode.php";
        public static String get_orders_for_generate_packing_list = "warehouse/packing_list/getOrdersList.php";
        public static String get_customers_for_generate_packing_list = "warehouse/packing_list/getCustomerList.php";
        public static String get_vendors_for_generate_packing_list = "warehouse/packing_list/getVendor.php";
        public static String get_fabric_type_for_generate_packing_list = "warehouse/packing_list/getFabricTypes.php";
        public static String get_colors_for_generate_packing_list = "warehouse/packing_list/getColors.php";
        //Cutting PHP API
        public static String cutting_generate_activity_code = "Cutting/generateActivityCode.php";
        public static String cutting_get_RFID_detail = "Cutting/getRFIDRollInfo.php";
        public static String cutting_get_insert_individual_roll = "Cutting/insertRollsForCutting.php";
        public static String cutting_insert_activity = "Cutting/insertFinalActivityProgress.php";
        // Cutting Node API
        public static String cutting_node_get_RFID_detail = "Reports/StockedOut_Rolls";
        public static String cutting_node_generate_activity_code = "Cutting/Generate_Activity";
        public static String cutting_node_get_insert_individual_roll = "Cutting/Activity_Roll_Mapping";
        public static String cutting_node_insert_activity = "Cutting/Submit_Wastage";
        //Asset Tracking PHP API
        public static String Asset_get_goods_complete_data = "AssetsTracking/getAllGoodsData.php";
        public static String Asset_parts_locations = "AssetsTracking/Machine_parts_consumption/getAllLocations.php";
        public static String Assets_get_locations = "AssetsTracking/getFloorsData.php";
        public static String Assets_update_locations = "AssetsTracking/insertRFIDTags.php";
        public static String upload_asset = "AssetsTracking/insertAssetsList.php";
        public static String update_price = "AssetsTracking/updateMachinePrice.php";
        public static String auto_update_machine_locations = "AssetsTracking/autoUpdateMachineLocations.php";
        public static String insert_part_list = "AssetsTracking/Machine_parts_consumption/insertPartsList.php";
        public static String get_part_list = "AssetsTracking/Machine_parts_consumption/getAllParts.php";
        public static String update_machine_line = "/AssetsTracking/UpdateMachineLine/UpdateMachineLine.php";
    }
}

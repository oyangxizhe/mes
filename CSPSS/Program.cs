using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSPSS
{
    static class Program
    {/// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LOGIN());//WO15070001-0002-0002-0004 /WO15070001-0008
            //Application.Run(new PRODUCTION_MANAGE.STEP_WAREID());
            //Application.Run(new PRODUCTION_MANAGE .STEP_WAREIDT ());
            //Application.Run(new PRODUCTION_MANAGE .BATCH_TO_PRODUCT ());
            //Application.Run(new CSPSS.BASE_INFO.EMPLOYEE_INFO ());
            //Application.Run(new CSPSS.BASE_INFO.MATERIALS ());
            //Application.Run(new BASE_INFO.MATERIALS());

            //Application.Run(new PRODUCTION_MANAGE.POSTINGT ());
            //Application.Run(new PRODUCTION_MANAGE.FLOW_CHART());
            // Application.Run(new PRODUCTION_MANAGE.FLOW_CHARTT());
            //Application.Run(new PRODUCTION_MANAGE.STEP());

            //Application.Run(new ABNORMAL_MANAGE.WIP_INTERRUPT ());
            //Application.Run(new ABNORMAL_MANAGE.BATCH_REMOVE ());

            //Application.Run(new WORKORDER_MANAGE.PRINT_AGAIN());
            //Application.Run(new WORKORDER_MANAGE.BATCHT());
            // Application.Run(new WORKORDER_MANAGE.UNIT_LOT());
            //Application.Run(new WORKORDER_MANAGE.WORKORDERT ());
            //Application.Run(new WORKORDER_MANAGE.BILL_NATURE ());

            //Application.Run(new QUALITY_MANAGE.BAD_PHENOMENON_BECAUSE());
            //Application.Run(new QUALITY_MANAGE.BAD_PHENOMENON());
            //Application.Run(new QUALITY_MANAGE.BAD_PHENOMENON_AND_GROUP());

            //Application.Run(new REPORT_MANAGE.BATCH_REMOVE_SEARCH());
            //Application.Run(new REPORT_MANAGE.BAD_PHENOMENON_SEARCH());
            //Application.Run(new REPORT_MANAGE.RESUME_SEARCH ());
            //Application.Run(new REPORT_MANAGE.ELECTRONIC_KB_FOR_STEP());
            //Application.Run(new REPORT_MANAGE.ELECTRONIC_KANBAN ());
            //Application.Run(new REPORT_MANAGE.BATCH_YIELD_SEARCH ());
            //Application.Run(new REPORT_MANAGE.ELECTRONIC_KANBAN ());
            //Application.Run(new REPORT_MANAGE.WIP_SEARCH());

            //Application.Run(new MACHINE_MANAGE.MACHINE_AND_GROUP());
            //Application.Run(new MACHINE_MANAGE.MACHINE());
            //Application.Run(new QUALITY_MANAGE.MACHINE_GROUP ());

            //Application.Run(new CSPSS.USER_MANAGE .USER_INFO ());
            //Application.Run(new MAIN());
            //Application.Run(new CSPSS.USER_MANAGE.EDIT_RIGHT ());

        
        }
    }
}

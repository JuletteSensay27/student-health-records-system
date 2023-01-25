using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_health_records_system
{
    internal class DBInteractions
    {
        private DataClasses1DataContext dbconn = new DataClasses1DataContext(Properties.Settings.Default.Student_Health_Record_SystemConnectionString);

        private void displayStudentRecords() 
        {

        }
    }
}

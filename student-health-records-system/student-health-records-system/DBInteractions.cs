using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace student_health_records_system
{
    internal class DBInteractions
    {
        private DataClasses1DataContext dbconn = new DataClasses1DataContext(Properties.Settings.Default.Student_Health_Record_SystemConnectionString);

        public Dictionary<string, string> getStudentRecords(string studentID) 
        {
            Dictionary<string,string> recordsCont = new Dictionary<string, string>();

            var result = dbconn.uspRetrieveStudentRecords(studentID).Single();

            recordsCont.Add("student_ID", result.studentID);
            recordsCont.Add("student_firstName", result.studentFName);
            recordsCont.Add("student_middleName", result.studentMName);
            recordsCont.Add("student_lastName", result.studentLName);
            recordsCont.Add("student_phoneNum", result.studentPhoneNum);
            recordsCont.Add("student_email", result.studentEmail);

            return recordsCont;
        }

        public Dictionary<string, List<string>> getStudentFiles(string studentID)
        {
            Dictionary<string, List<string>> filesCont = new Dictionary<string, List<string>>();
            List<string> file = new List<string>();
            int fileCounter = 0;

            var result = dbconn.uspRetrieveStudentFiles(studentID).ToList();

            while (fileCounter < result.Count) 
            {
                file = new List<string>();
                file.Add(result.ElementAt(fileCounter).fileID);
                file.Add(result.ElementAt(fileCounter).fileName);
                file.Add(result.ElementAt(fileCounter).fileType);
                file.Add(result.ElementAt(fileCounter).fileRecordType);
                file.Add(result.ElementAt(fileCounter).fileLocation);

                filesCont.Add($"file{fileCounter}", file);
                fileCounter++;
            }

            return filesCont;
        }

        public string[] userLogin(string userName, string userPassword)  
        {
            string[] errorArray = new string[2];
            int invalidCounter = 0;
            var adminUsernames = dbconn.uspGetAdminUsernames().ToList();

            for (int i = 0; i < adminUsernames.Count; i++) 
            {
                if (userName != adminUsernames.ElementAt(i).adminUsername) 
                {
                    invalidCounter++;
                }
            }

            if (invalidCounter > adminUsernames.Count - 1) 
            {
                for (int i = 0; i < errorArray.Length; i++) 
                {
                    switch (i) 
                    {
                        case 0:
                            errorArray[i] = "Login Error";
                        break;
                        case 1:
                            errorArray[i] = "Username not found!";
                            break;
                    }
                }

                invalidCounter= 0;
                return errorArray;
            }

            var adminCredentials = dbconn.uspGetAdminCredentials(userName).ToList();

            if (userPassword != adminCredentials.ElementAt(0).adminPassword)
            {
                for (int i = 0; i < errorArray.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            errorArray[i] = "Login Error";
                            break;
                        case 1:
                            errorArray[i] = "Incorrect Username/Password!";
                            break;
                    }
                }

                return errorArray;
            }

            if (adminCredentials.ElementAt(0).adminStatus != "OFL") 
            {
                for (int i = 0; i < errorArray.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            errorArray[i] = "Login Error";
                            break;
                        case 1:
                            errorArray[i] = "Account Already Online!";
                            break;
                    }
                }

                return errorArray;
            }

            switch (adminCredentials.ElementAt(0).adminAccess) 
            {
                case "IAD":
                    for (int i = 0; i < errorArray.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                errorArray[i] = "Login Success!";
                                break;
                            case 1:
                                errorArray[i] = "Welcome IT Admin!";
                                break;
                        }
                    }
                    break;

                case "NAD":
                    for (int i = 0; i < errorArray.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                errorArray[i] = "Login Success!";
                                break;
                            case 1:
                                errorArray[i] = "Welcome Nurse Admin!";
                                break;
                        }
                    }
                    break;
            }

            dbconn.uspUpdateAccountStatusLogIn(userName);

            invalidCounter = 0;
            return errorArray;
        }

        public string[] userLogout(string userName)
        {
            string[] errorArray = new string[2];

                for (int i = 0; i < errorArray.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            errorArray[i] = "Logout Successful!";
                            break;
                        case 1:
                            errorArray[i] = "See You Again !";
                            break;
                    }
                }

            dbconn.uspUpdateAccountStatusLogOut(userName);

            return errorArray;
        }

        public string[] userRegistration(List<Object> userInfo) 
        {
            string[] errorArray = new string[2];
            
            var adminIDs = dbconn.uspGetAdminIDs().ToList();

            for (int i = 0; i < adminIDs.Count; i++) 
            {
                if (userInfo.ElementAt(0).ToString() == adminIDs.ElementAt(i).admin_ID.ToString()) 
                {
                    for (int h = 0; h < errorArray.Length; h++)
                    {
                        switch (h)
                        {
                            case 0:
                                errorArray[h] = "Registration Error!";
                                break;
                            case 1:
                                errorArray[h] = "User Account Already Existing!";
                                break;
                        }
                    }
                    
                    return errorArray; 
                }
            }

            var adminUsernames = dbconn.uspGetAdminUsernames().ToList();

            for (int i = 0; i < adminUsernames.Count; i++)
            {
                if (userInfo.ElementAt(4).ToString() == adminUsernames.ElementAt(i).adminUsername.ToString())
                {
                    for (int h = 0; h < errorArray.Length; h++)
                    {
                        switch (h)
                        {
                            case 0:
                                errorArray[h] = "Registration Error!";
                                break;
                            case 1:
                                errorArray[h] = "Username Already Existing!";
                                break;
                        }
                    }

                    return errorArray;
                }
            }

            var registerAdmin = dbconn.uspRegisterAdmin(
                userInfo.ElementAt(0).ToString(),
                userInfo.ElementAt(1).ToString(),
                userInfo.ElementAt(2).ToString(),
                userInfo.ElementAt(3).ToString(),
                userInfo.ElementAt(4).ToString(),
                userInfo.ElementAt(5).ToString(),
                userInfo.ElementAt(6).ToString(),
                userInfo.ElementAt(7).ToString(),
                userInfo.ElementAt(8).ToString(),
                userInfo.ElementAt(9).ToString(),
               DateTime.Parse(userInfo.ElementAt(10).ToString()),
                DateTime.Parse(userInfo.ElementAt(11).ToString())
                );

            for (int i = 0; i < errorArray.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        errorArray[i] = "Registration Success!";
                        break;
                    case 1:
                        errorArray[i] = "Account Added!";
                        break;
                }
            }

            return errorArray;
        }

        public string[] userUpdates(List<Object> userInfo) 
        {
            string[] errorArray = new string[2];
            int invalidCounter = 0;

            var getAdminIDs = dbconn.uspGetAdminIDs().ToList();

            for (int i = 0; i < getAdminIDs.Count; i++) 
            {
                if (userInfo.ElementAt(0).ToString() != getAdminIDs.ElementAt(i).admin_ID) 
                {
                    invalidCounter++;
                }
            }

            if (invalidCounter > getAdminIDs.Count - 1) 
            {
                for (int h = 0; h < errorArray.Length; h++)
                {
                    switch (h)
                    {
                        case 0:
                            errorArray[h] = "Update Error!";
                            break;
                        case 1:
                            errorArray[h] = "User is not existing!";
                            break;
                    }
                }

                return errorArray;
            }

            var getCurrentAdminUsername = dbconn.uspGetAdminUsernameByAdminID(userInfo.ElementAt(0).ToString()).Single();

            if (userInfo.ElementAt(4).ToString() != getCurrentAdminUsername.ToString()) 
            {
                var checkUsernameExistence = dbconn.uspCheckAdminUsernameExistence(userInfo.ElementAt(0).ToString(),
                                                    userInfo.ElementAt(4).ToString());

                if (int.Parse(checkUsernameExistence.ToString()) > 0) 
                {
                    for (int h = 0; h < errorArray.Length; h++)
                    {
                        switch (h)
                        {
                            case 0:
                                errorArray[h] = "Update Error!";
                                break;
                            case 1:
                                errorArray[h] = "Username already exists!";
                                break;
                        }
                    }

                    return errorArray;
                }
            }

            var updateUser = dbconn.uspUpdateAdmin(
                userInfo.ElementAt(0).ToString(),
                userInfo.ElementAt(1).ToString(),
                userInfo.ElementAt(2).ToString(),
                userInfo.ElementAt(3).ToString(),
                userInfo.ElementAt(4).ToString(),
                userInfo.ElementAt(5).ToString(),
                userInfo.ElementAt(6).ToString(),
                userInfo.ElementAt(7).ToString(),
                userInfo.ElementAt(8).ToString(),
                userInfo.ElementAt(9).ToString(),
                userInfo.ElementAt(10).ToString(),
                DateTime.Parse(userInfo.ElementAt(11).ToString())
                );


            for (int h = 0; h < errorArray.Length; h++)
            {
                switch (h)
                {
                    case 0:
                        errorArray[h] = "Update Complete!";
                        break;
                    case 1:
                        errorArray[h] = "Updated Admin Information!";
                        break;
                }
            }


            return errorArray;
        }

    }
}

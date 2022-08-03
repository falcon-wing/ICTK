using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecIotAgent.Forms;

namespace SecIotAgent.PROCESS
{
    internal class ProcessClass
    {
        public ProcessClass()
        {
            //
        }

        public bool AuthenticationUser()
        {
            LoginV2Form login = new LoginV2Form();
            DialogResult ret = login.ShowDialog();
            
            if (ret == DialogResult.OK)
                return true;
            return false;
        }

        public bool AuthenticationPUF_N_Finger()
        {
            FingerAuthForm fingerAuthForm = new FingerAuthForm();
            DialogResult ret = fingerAuthForm.ShowDialog();

            if (ret == DialogResult.OK)
                return true;
            return false;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadInventoryUI.ViewModel
{
    //public class ProjectsLib : NotificationObject
    //{

    //    private string _name;
    //    public string Name
    //    {
    //        get
    //        {
    //            return _name;
    //        }
    //        set 
    //        {
    //            _name = value;
    //            this.RaisePropertyChanged("Name");
    //        }
    //    }
    //    public List<Project> Projects { get; set; }
    //}

    public class ProjectsLib : NotificationObject
    {

        private string _name;
        public string ProjectsLibName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
               
            }
        }

        // 一个库所有的清单规则
        private List<BQRuleVM> _bqRuleVMList = new List<BQRuleVM>();
        public List<BQRuleVM> BQRuleVMList
        {
            get
            {
                return _bqRuleVMList;
            }
            set
            {
                _bqRuleVMList = value;
            }
        }

        // 按清单编码搜索
        public List<BQRuleVM> SearchBqRulesByCode(string code)
        {
            List<BQRuleVM> bqRulesRes = new List<BQRuleVM>();
            for (int i = 0; i < _bqRuleVMList.Count; i++)
            {
                if (_bqRuleVMList[i].Code == code)
                {
                    bqRulesRes.Add(_bqRuleVMList[i]);
                }
            }
            return bqRulesRes;
        }

        // 按项目名称搜索
        public List<BQRuleVM> SearchBqRulesByProject(string projectName)
        {
            List<BQRuleVM> bqRulesRes = new List<BQRuleVM>();

            for (int i = 0; i < _bqRuleVMList.Count; i++)
            {
                if (_bqRuleVMList[i].ProjectName == projectName)
                {
                    bqRulesRes.Add(_bqRuleVMList[i]);
                }
            }
            return bqRulesRes;
        }


        public List<BQRuleVM> SearchBqRulesByCodes(List<string> bqRuleVMCodeList)
        {
            List<BQRuleVM> bqRulesRes = new List<BQRuleVM>();

            for (int i = 0; i < _bqRuleVMList.Count; i++)
            {
                int pos = -1;
                for (int j = 0; j < bqRuleVMCodeList.Count; j++)
                {
                    if (_bqRuleVMList[i].Code == bqRuleVMCodeList[j])
                    {
                        pos = j;
                        break;
                    }
                }

                if ( pos != -1)
                {
                    bqRulesRes.Add(_bqRuleVMList[i]);
                }
            }
            return bqRulesRes;
        }


       

        private List<Project> _projects = new List<Project>(); 
        public List<Project> Projects 
        {
            get
            {
                return _projects;
            }
            set
            {
                _projects = value;
            }
        }

        // 一个库里所有的规则
        //public List<BQRuleVM> BQRuleVMList = new List<BQRuleVM>();

    }
}

using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadInventoryUI.ViewModel
{
    public class Project : NotificationObject
    {
        public Project()
        {
            this.ChildNodes = new List<Project>();
            this.ParentId = 0;//主节点的父id默认为0
        }

        public Project(int id,int parId,string name,string code)
        {
            this.ChildNodes = new List<Project>();
            this.ID = id;          
            this.ParentId = parId;
            this.Name = name;
            this.Code = code;
        }

        public List<Project> ChildNodes { get; set; }
        public int ID { get; set; }
        public int ParentId { get; set; }//parentID
        public string Name { get; set; }
        public string Code { get; set; }

        private ProjectsLib _prijectsLib = new ProjectsLib();
        public ProjectsLib ProjectsLibIn
        {
            set
            {
                _prijectsLib = value;
            }
            get
            {
                return _prijectsLib;
            }
        }
 

        // 变成一个属性
        //public List<BQRuleVM> BQRuleVMList = new List<BQRuleVM>();
        public List<BQRuleVM> BQRuleVMList
        {
            get
            {
                List<BQRuleVM> bqRuleVMList = _prijectsLib.SearchBqRulesByCodes(BQRuleVMCodeList);

                for (int i = 0; i < bqRuleVMList.Count; i++)
                {
                    bqRuleVMList[i].ID = (i+1).ToString();
                }

                return bqRuleVMList;
            }

        }

        public List<string> BQRuleVMCodeList = new List<string>();


        bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                LoadInventoryViewModel.VM.ProjectCur = this;
                this.RaisePropertyChanged("IsSelected");
            }
        }
    }
}

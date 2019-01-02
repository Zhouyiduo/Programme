
using LoadInventoryUI.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LoadInventoryUI.ViewModel
{
   
    public class LoadInventoryViewModel : NotificationObject
    {
        public static LoadInventoryViewModel VM = null;

        public void SetData(List<ProjectsLib> projectLibs)
        {
            _projectsLibList = projectLibs;

            if (_projectsLibList.Count != 0)
            {
                _selectedProjectsLib = _projectsLibList[0];
                _projectExplore = _projectsLibList[0].Projects;

                if (_projectExplore.Count != 0)
                {
                    ProjectCur = _projectExplore[0];
                }
            }
            
        }
        
        private List<ProjectsLib> _projectsLibList = new List<ProjectsLib>();
        public List<ProjectsLib> ProjectsLibList
        {
            get
            {
                return _projectsLibList;
            }
            set
            {
                _projectsLibList = value;
                this.RaisePropertyChanged("ProjectsLibList");
            }
        }

        private ProjectsLib _selectedProjectsLib = new ProjectsLib();
        public ProjectsLib SelectedProjectsLib
        {
            get
            {
                return this._selectedProjectsLib;
            }
            set
            {
                if (!this._selectedProjectsLib.Equals(value))
                {
                    this._selectedProjectsLib = value;
                    ProjectExplore = this._selectedProjectsLib.Projects;
                    this.RaisePropertyChanged("SelectedProjectsLib");
                }
            }
        }


        // 工程预览
        private List<Project> _projectExplore { get; set; }
        public List<Project> ProjectExplore
        {
            get
            {
                return _projectExplore;
            }
            set
            {
                _projectExplore = value;
                this.RaisePropertyChanged("ProjectExplore");
            }
        }

        //// 当前选择工程
        private Project _projectCur = new Project();
        public Project ProjectCur
        {
            get
            {
                return _projectCur;
            }
            set
            {
                _projectCur = value;
                BQRuleVMList = _projectCur.BQRuleVMList;
                //this.RaisePropertyChanged("ProjectCur");
            }
        }


        // 列表控件调试
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
                this.RaisePropertyChanged("BQRuleVMList");
            }
        }

        private string _searchContext;
        public string SearchContext
        {
            get
            {
                return _searchContext;
            }
            set
            {
                _searchContext = value;
                this.RaisePropertyChanged("SearchContext");
            }
        }

        public LoadInventoryViewModel()
        {
            //构建测试数据
            //List<ProjectsLib> projectsLibList = new List<ProjectsLib>();
            //InitProsLib(ref projectsLibList);
            //_projectsLibList = projectsLibList;

            if (_projectsLibList.Count != 0)
            {
                _selectedProjectsLib = _projectsLibList[0];
                _projectExplore = _projectsLibList[0].Projects;

                if (_projectExplore.Count != 0)
                {
                    ProjectCur = _projectExplore[0];
                }
            }

            //SearchContext = "搜索内容";
            return;
        }

        private void InitProsLib(ref List<ProjectsLib> projectsLibList)
        {
            ProjectsLib projectsLib1= new ProjectsLib(),projectsLib2 = new ProjectsLib(),projectsLib3 = new ProjectsLib();;
            List<Project> projectExplore1 = new List<Project>(),projectExplore2 = new List<Project>(),projectExplore3 = new List<Project>();

            projectsLib1.ProjectsLibName = "标准清单价1";
            InitTreeInfo(ref projectExplore1,"A");
            projectsLib1.Projects = projectExplore1;

            projectsLib2.ProjectsLibName = "标准清单价2";
            InitTreeInfo(ref projectExplore2,"B");
            projectsLib2.Projects = projectExplore2;

            projectsLib3.ProjectsLibName = "标准清单价3";
            InitTreeInfo(ref projectExplore3,"C");
            projectsLib3.Projects = projectExplore3;

            projectsLibList.Add(projectsLib1);
            projectsLibList.Add(projectsLib2);
            projectsLibList.Add(projectsLib3);

        }

        // @test
        // 初始化一个树形
        private void InitTreeInfo(ref List<Project> projects,string index)
        {
            //Project project1 = new Project(1, 0, index + "01 土石工程", "01");
            //Project project2 = new Project(2, 0, index + "02 地基处理与边坡支护工程", "02");
            //Project project3 = new Project(3, 0, index + "03 地基与桩基工程","03");

            //Project subProject11 = new Project(11, 1, index + "01_1 开挖工程","011");
            //Project subProject12 = new Project(12, 1, index + "01_2 开挖工程", "012");
            //Project subProject13 = new Project(13, 1, index + "01_3 开挖工程","012");


            ////Project subProject111 = new Project(111, 11, index + "01_1_1 地基处理与边坡支护工程");
            ////subProject11.ChildNodes.Add(subProject111);

            //Project subProject21 = new Project(21, 2, index + "02_1 地基处理与边坡支护工程", "021");
            //Project subProject22 = new Project(22, 2, index + "02_2 地基处理与边坡支护工程", "022");
            //Project subProject23 = new Project(23, 2, index + "02_2 地基处理与边坡支护工程", "023");


            //List<BQRuleVM> bqRuleVMListA = new List<BQRuleVM>(), bqRuleVMListB = new List<BQRuleVM>(), bqRuleVMListC = new List<BQRuleVM>();
            //InitBillList(ref bqRuleVMListA,"A");
            //InitBillList(ref bqRuleVMListB,"B");
            //InitBillList(ref bqRuleVMListC,"C");

            //project1.BQRuleVMList = bqRuleVMListA;
            //project2.BQRuleVMList = bqRuleVMListB;
            //project3.BQRuleVMList = bqRuleVMListC;

            //project1.ChildNodes.Add(subProject11);
            //project1.ChildNodes.Add(subProject12);
            //project1.ChildNodes.Add(subProject13);

            //project2.ChildNodes.Add(subProject21);
            //project2.ChildNodes.Add(subProject22);
            //project2.ChildNodes.Add(subProject23);

            //projects.Add(project1);
            //projects.Add(project2);
            //projects.Add(project3);

        }

        private void InitBillList(ref List<BQRuleVM> bqRuleVMList,string index)
        {
            bqRuleVMList.Add(new BQRuleVM("1", index + "0405001", "有梁板", "构件类型=现浇板,类别=有梁板;", "TJ<体积>"));
            bqRuleVMList.Add(new BQRuleVM("2", index + "0405002", "有梁板模板", "构件类型=现浇板,类别=有梁板;", "MBMJ<模板面积>;\nMBMJ-1<模板面积>;"));
            bqRuleVMList.Add(new BQRuleVM("3", index + "0405003", "无梁板", "构件类型=现浇板,类别=有梁板;\n构件类型=柱帽", "MBMJ<模板面积>;\nMBMJ-1<模板面积>;"));
        }

        //public ICommand selectionChangedCommand { get; set; }
        //public void selectionChanged()
        //{
        //    //MessageBox.Show(BillIndex.ToString());
        //}

        //public ICommand treeSlectionChangedCommand { get; set; }
        //public void treeSlectionChanged()
        //{
        //    MessageBox.Show("Hi");
        //}

    }
}

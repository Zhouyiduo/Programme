using LoadInventoryUI.Model;
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
    class LoadInventoryViewModel : NotificationObject
    {
        public DataBQRules DataIns = new DataBQRules();

        //private List<string> _lsTest { get; set; }           // 组合框调试
        //private string _sBillsSeach { get; set; }     // 文本框调试 

        //private List<ProjectsLib> _projectsLibList = new List<ProjectsLib>();
        //public List<ProjectsLib> ProjectsLibList
        //{
        //    get
        //    {
        //        return _projectsLibList; 
        //    }
        //    set
        //    {
        //        _projectsLibList = value;
        //        this.RaisePropertyChanged("ProjectsLibList");
        //    }
        //}
        //private List<Project> _ProjectExplore { get; set; } // 树形控件调试
        //private List<BQRuleVM> _BQRuleVMList { get; set; }  // 列表控件调试

        //private int _BillIndex { get; set; }
        //private string _BillName { get; set; }
        //private Project _ProjectCur { get; set; }
        //private string _EleName { get; set; }

        // 所有的清单
        //public List<string> lstBillName
        //{
        //    get 
        //    { 
        //        return _lsTest; 
        //    }
        //    set
        //    {
        //        lstBillName = value;
        //        this.RaisePropertyChanged("lstBillName");
        //    }
        //}

        //// 当前选择的清单
        //public string BillName
        //{
        //    get
        //    {
        //        return _BillName;
        //    }
        //    set
        //    {
        //        _BillName = value;
        //        this.RaisePropertyChanged("BillName");
        //    }
        //}

        //public int BillIndex
        //{
        //    get
        //    {
        //        return _BillIndex;
        //    }
        //    set
        //    {
        //        _BillIndex = value;
        //        this.RaisePropertyChanged("BillIndex");
        //    }
        //}


        //public string BillsSeach
        //{
        //    get 
        //    { 
        //        return _sBillsSeach;
        //    }
        //    set
        //    {
        //        _sBillsSeach = value;
        //        this.RaisePropertyChanged("BillsSeach");
        //    }
        //}

        // 工程预览
        //public List<Project> ProjectExplore
        //{
        //    get { return _ProjectExplore; }
        //    set
        //    {
        //        ProjectExplore = value;
        //        this.RaisePropertyChanged("ProjectExplore");
        //    }
        //}

        //// 当前选择工程
        //public Project ProjectCur
        //{
        //    get 
        //    {
        //        return ProjectCur;
        //    }
        //    set
        //    {
        //        ProjectCur = value;
        //        this.RaisePropertyChanged("ProjectCur");
        //    }
        //}

        // 清单列表
        //public List<BQRuleVM> BillList
        //{
        //    get 
        //    { 
        //        return _BillsList; 
        //    }
        //    set
        //    {
        //        BillList = value;
        //        this.RaisePropertyChanged("BillList");
        //    }
        //}

        //bool _isSelected;
        //public bool IsSelected
        //{
        //    get
        //    {
        //        return _isSelected;
        //    }
        //    set
        //    {
        //        _isSelected = value;
        //        this.RaisePropertyChanged("IsSelected");
        //        //MessageBox.Show("选中的!!");
        //    }
        //}

        //bool _isChecked;
        //public bool IsChecked
        //{
        //    get 
        //    {
        //        return _isChecked;
        //    }
        //    set 
        //    {
        //        _isChecked = value;
        //        this.RaisePropertyChanged("IsChecked");
        //        MessageBox.Show("选中的!!");

        //    }

        //}

        //public LoadInventoryViewModel()
        //{
        //    //构建测试数据
        //    //List<string> lstTest = new List<string>();
        //    //lstTest.Add("清单A");
        //    //lstTest.Add("清单B");
        //    //lstTest.Add("清单C");
        //    //_lsTest = lstTest;
        //    //_sBillsSeach = "搜索";

        //    List<ProjectsLib> projectsLibList = new List<ProjectsLib>();
        //    InitProsLib(ref projectsLibList);
        //    ProjectsLibList = projectsLibList;

        //    // 树形控件调试
        //    //List<Project> projectExplore = new List<Project>();
        //    //InitTreeInfo(ref projectExplore);
        //    //_ProjectExplore = projectExplore;

        //    //List<BQRuleVM> bqRuleVMList = new List<BQRuleVM>();
        //    //InitBillList(ref bqRuleVMList);
        //    //_BQRuleVMList = bqRuleVMList;

        //    //public string sBillsList { get; set; }  // 列表控件调试

        //    //if (_BQRuleVMList.Count != 0)
        //    //{
        //    //    _BillName = _BQRuleVMList[0].BillName;
        //    //}

        //    _BillIndex = 1;

        //    selectionChangedCommand = new DelegateCommand(selectionChanged);   //初始化delegatecommand

        //    BQRuleOpert.ReadData(ref DataIns);

        //}

        //private void InitProsLib(ref List<ProjectsLib> projectsLibList)
        //{
        //    ProjectsLib projectsLib = new ProjectsLib();
        //    projectsLib.Name = "标准清单价1";
        //    List<Project> projectExplore = new List<Project>();
        //    InitTreeInfo(ref projectExplore);

        //    projectsLibList.Add(projectsLib);
        //    projectsLib.Name = "标准清单价2";

        //    projectsLibList.Add(projectsLib);

        //    projectsLib.Name = "标准清单价3";
        //    projectsLibList.Add(projectsLib);


        //}

        // 初始化一个树形
        //private void InitTreeInfo(ref List<Project> projects)
        //{
        //    Project project1 = new Project(1, 0, "A01 土石工程");
        //    Project project2 = new Project(2, 0, "A02 地基处理与边坡支护工程");
        //    Project project3 = new Project(3, 0, "A03 地基与桩基工程");

        //    Project subProject11 = new Project(11, 1, "A01_1 开挖工程");
        //    Project subProject12 = new Project(12, 1, "A01_2 开挖工程");
        //    Project subProject13 = new Project(13, 1, "A01_3 开挖工程");

        //    Project subProject21 = new Project(21, 2, "A02_1 地基处理与边坡支护工程");
        //    Project subProject22 = new Project(22, 2, "A02_2 地基处理与边坡支护工程");
        //    Project subProject23 = new Project(23, 2, "A02_2 地基处理与边坡支护工程");


        //    project1.ChildNodes.Add(subProject11);
        //    project1.ChildNodes.Add(subProject12);
        //    project1.ChildNodes.Add(subProject13);

        //    project2.ChildNodes.Add(subProject21);
        //    project2.ChildNodes.Add(subProject22);
        //    project2.ChildNodes.Add(subProject23);

        //    projects.Add(project1);
        //    projects.Add(project2);
        //    projects.Add(project3);

        //    //projects.Add(subProject11);
        //    //projects.Add(subProject12);
        //    //projects.Add(subProject13);

        //    //projects.Add(subProject21);
        //    //projects.Add(subProject22);
        //    //projects.Add(subProject23);

        //}
        //private void InitBillList(ref List<BQRuleVM> bqRuleVMList)
        //{
        //    bqRuleVMList.Add(new BQRuleVM("1", "A0405001", "有梁板", "构件类型=现浇板,类别=有梁板;", "TJ<体积>"));
        //    bqRuleVMList.Add(new BQRuleVM("2", "A0405002", "有梁板模板", "构件类型=现浇板,类别=有梁板;", "MBMJ<模板面积>;\nMBMJ-1<模板面积>;"));
        //    bqRuleVMList.Add(new BQRuleVM("3", "A0405003", "无梁板", "构件类型=现浇板,类别=有梁板;\n构件类型=柱帽", "MBMJ<模板面积>;\nMBMJ-1<模板面积>;"));
        //}

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

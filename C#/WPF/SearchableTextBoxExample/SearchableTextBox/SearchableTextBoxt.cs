using SearchableTextBox.Helpers;
using SearchableTextBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchableTextBox
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:SearchableTextBox"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:SearchableTextBox;assembly=SearchableTextBox"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class SearchableTextBox : Control
    {
        #region Consts

        private const string SEARCH_ICON_STRING = "F1 M 14.8076,31.1139L 20.0677,25.9957C 19.3886,24.8199 19.25,23.4554 19.25,22C 19.25,17.5817 22.5817,14 27,14C 31.4183,14 35,17.5817 35,22C 35,26.4183 31.4183,29.75 27,29.75C 25.6193,29.75 24.3204,29.6502 23.1868,29.0345L 17.8861,34.1924C 17.105,34.9734 15.5887,34.9734 14.8076,34.1924C 14.0266,33.4113 14.0266,31.895 14.8076,31.1139 Z M 27,17C 24.2386,17 22,19.2386 22,22C 22,24.7614 24.2386,27 27,27C 29.7614,27 32,24.7614 32,22C 32,19.2386 29.7614,17 27,17 Z";

        #endregion

        #region Fields

        private TextBlock _ttbSearchTips = null;
        private TextBox _ttbInput = null;
        private Button _btnClear = null;
        private Popup _popup = null;
        private ListBox _lstSearchResult = null;
        private bool _canSearching = true;

        #endregion

        #region Propreties

        public Func<string, IList<SearchModel>, IList<SearchModel>> SearchMethod { get; set; }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// 控件圆角半径
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty
            = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(SearchableTextBox), new PropertyMetadata(new CornerRadius(0), null));
        /// <summary>
        /// 是否显示搜索图标
        /// </summary>
        public static readonly DependencyProperty IsShowSearchIconProperty
            = DependencyProperty.Register("IsShowSearchIcon", typeof(bool), typeof(SearchableTextBox), new PropertyMetadata(true, null));
        /// <summary>
        /// 搜索图标前景色
        /// </summary>
        public static readonly DependencyProperty SearchIconForegroundProperty
            = DependencyProperty.Register("SearchIconForeground", typeof(Brush), typeof(SearchableTextBox), new PropertyMetadata(new SolidColorBrush(Colors.Gray), null));
        /// <summary>
        /// 搜索图标
        /// </summary>
        public static readonly DependencyProperty SearchIconProperty
            = DependencyProperty.Register("SearchIcon", typeof(Geometry), typeof(SearchableTextBox), new PropertyMetadata(Geometry.Parse(SEARCH_ICON_STRING), null));
        /// <summary>
        /// 搜索图标高度
        /// </summary>
        public static readonly DependencyProperty SearchIconHeightProperty
            = DependencyProperty.Register("SearchIconHeight", typeof(double), typeof(SearchableTextBox), new PropertyMetadata(16.0, null));
        /// <summary>
        /// 搜索图标宽度
        /// </summary>
        public static readonly DependencyProperty SearchIconWidthProperty
            = DependencyProperty.Register("SearchIconWidth", typeof(double), typeof(SearchableTextBox), new PropertyMetadata(16.0, null));
        /// <summary>
        /// 是否显示搜索提示文字
        /// </summary>
        public static readonly DependencyProperty IsShowSearchTipsProperty
            = DependencyProperty.Register("IsShowSearchTips", typeof(bool), typeof(SearchableTextBox), new PropertyMetadata(true, null));
        /// <summary>
        /// 只是是否可以显示搜索框
        /// </summary>
        public static readonly DependencyProperty CanShowSearchTipsProperty
            = DependencyProperty.Register("CanShowSearchTips", typeof(bool), typeof(SearchableTextBox), new PropertyMetadata(true, null));
        /// <summary>
        /// 搜索提示文字
        /// </summary>
        public static readonly DependencyProperty SearchTipsProperty
            = DependencyProperty.Register("SearchTips", typeof(string), typeof(SearchableTextBox), new PropertyMetadata("请输入搜索条件", null));
        /// <summary>
        /// 搜索提示文字颜色
        /// </summary>
        public static readonly DependencyProperty SearchTipsForegroundProperty
            = DependencyProperty.Register("SearchTipsForeground", typeof(Brush), typeof(SearchableTextBox), new PropertyMetadata(new SolidColorBrush(Colors.Gray), null));
        /// <summary>
        /// 是否显示全部搜索结果
        /// </summary>
        public static readonly DependencyProperty IsShowAllSearchResultProperty
            = DependencyProperty.Register("IsShowAllSearchResult", typeof(bool), typeof(SearchableTextBox), new PropertyMetadata(true, null));
        /// <summary>
        /// （在不显示全部搜索结果的条件下）可显示的搜索结果的最大数据量
        /// </summary>
        public static readonly DependencyProperty MaxShownResultCountProperty
            = DependencyProperty.Register("MaxShownResultCount", typeof(int), typeof(SearchableTextBox), new PropertyMetadata(10, null));
        /// <summary>
        /// 传入的搜索源
        /// </summary>
        public static readonly DependencyProperty SearchItemsSourceProperty
            = DependencyProperty.Register("SearchItemsSource", typeof(IList<SearchModel>), typeof(SearchableTextBox), new PropertyMetadata(null, null));
        /// <summary>
        /// 搜索结果集合（用于绑定到ListBox）
        /// </summary>
        public static readonly DependencyProperty SearchResultCollectionProperty
            = DependencyProperty.Register("SearchResultCollection", typeof(ObservableCollection<SearchModel>), typeof(SearchableTextBox), new PropertyMetadata(new ObservableCollection<SearchModel>(), null));
        /// <summary>
        /// 是否允许显示清除按钮
        /// </summary>
        public static readonly DependencyProperty CanShowClearButtonProperty
            = DependencyProperty.Register("CanShowClearButton", typeof(bool), typeof(SearchableTextBox), new PropertyMetadata(true, OnCanShowClearButtonPropertyChanged));
        /// <summary>
        /// 输入的搜索条件字符串
        /// </summary>
        public static readonly DependencyProperty SearchTextProperty
            = DependencyProperty.Register("SearchText", typeof(string), typeof(SearchableTextBox), new PropertyMetadata("", OnSearchTextPropretyChanged));
        /// <summary>
        /// 选中的搜索结果项
        /// </summary>
        public static readonly DependencyProperty SelectedSearchItemProperty
            = DependencyProperty.Register("SelectedSearchItem", typeof(SearchModel), typeof(SearchableTextBox), new PropertyMetadata(null));
        #endregion

        #region Dependency Property Wrappers

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public bool IsShowSearchIcon
        {
            get { return (bool)GetValue(IsShowSearchIconProperty); }
            set { SetValue(IsShowSearchIconProperty, value); }
        }
        public Brush SearchIconForeground
        {
            get { return (Brush)GetValue(SearchIconForegroundProperty); }
            set { SetValue(SearchIconForegroundProperty, value); }
        }
        public Geometry SearchIcon
        {
            get { return (Geometry)GetValue(SearchIconProperty); }
            set { SetValue(SearchIconProperty, value); }
        }
        public double SearchIconHeight
        {
            get { return (double)GetValue(SearchIconHeightProperty); }
            set { SetValue(SearchIconHeightProperty, value); }
        }
        public double SearchIconWidth
        {
            get { return (double)GetValue(SearchIconWidthProperty); }
            set { SetValue(SearchIconWidthProperty, value); }
        }
        public bool IsShowSearchTips
        {
            get { return (bool)GetValue(IsShowSearchTipsProperty); }
            set { SetValue(IsShowSearchTipsProperty, value); }
        }
        public bool CanShowSearchTips
        {
            get { return (bool)GetValue(CanShowSearchTipsProperty); }
            set { SetValue(CanShowSearchTipsProperty, value); }
        }
        public string SearchTips
        {
            get { return (string)GetValue(SearchTipsProperty); }
            set { SetValue(SearchTipsProperty, value); }
        }
        public Brush SearchTipsForeground
        {
            get { return (Brush)GetValue(SearchTipsForegroundProperty); }
            set { SetValue(SearchTipsForegroundProperty, value); }
        }
        public bool IsShowAllSearchResult
        {
            get { return (bool)GetValue(IsShowAllSearchResultProperty); }
            set { SetValue(IsShowAllSearchResultProperty, value); }
        }
        public int MaxShownResultCount
        {
            get { return (int)GetValue(MaxShownResultCountProperty); }
            set { SetValue(MaxShownResultCountProperty, value); }
        }
        public IList<SearchModel> SearchItemsSource
        {
            get
            {
                return (IList<SearchModel>)GetValue(SearchItemsSourceProperty);
            }
            set
            {
                SetValue(SearchItemsSourceProperty, value);
            }
        }
        public ObservableCollection<SearchModel> SearchResultCollection
        {
            get { return (ObservableCollection<SearchModel>)GetValue(SearchResultCollectionProperty); }
            set { SetValue(SearchResultCollectionProperty, value); }
        }
        public bool CanShowClearButton
        {
            get { return (bool)GetValue(CanShowClearButtonProperty); }
            set { SetValue(CanShowClearButtonProperty, value); }
        }
        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }
        public SearchModel SelectedSearchItem
        {
            get { return (SearchModel)GetValue(SelectedSearchItemProperty); }
            set { SetValue(SelectedSearchItemProperty, value); }
        }
        #endregion

        #region Routed Events

        /// <summary>
        /// 搜索结果选择改变事件
        /// </summary>
        public static readonly RoutedEvent SelectedSearchItemChangedEvent
            = EventManager.RegisterRoutedEvent("SelectedSearchItemChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SearchableTextBox));

        #endregion

        #region Event Wrappers

        public event RoutedEventHandler SelectedSearchItemChanged
        {
            add
            {
                base.AddHandler(SelectedSearchItemChangedEvent, value);
            }
            remove
            {
                base.RemoveHandler(SelectedSearchItemChangedEvent, value);
            }
        }

        #endregion

        #region Constructors

        static SearchableTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchableTextBox), new FrameworkPropertyMetadata(typeof(SearchableTextBox)));
        }

        #endregion

        #region Override Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PreviewKeyDown += SearchableTextBox_PreviewKeyDown;

            _ttbSearchTips = GetTemplateChild("PART_TextBlockTips") as TextBlock;
            _ttbInput = GetTemplateChild("PART_TextBoxInput") as TextBox;
            if (_ttbInput != null)
            {
                _ttbInput.TextChanged += _ttbInput_TextChanged;
            }
            _popup = GetTemplateChild("PART_Popup") as Popup;
            _lstSearchResult = GetTemplateChild("PART_ListBoxSearchResult") as ListBox;
            if (_lstSearchResult != null)
            {
                _lstSearchResult.PreviewMouseLeftButtonDown += _lstSearchResult_PreviewMouseLeftButtonDown;
            }
            _btnClear = GetTemplateChild("PART_ButtonClear") as Button;
            if (_btnClear != null)
            {
                _btnClear.Click += _btnClear_Click;
            }
        }

        #endregion

        #region Property Changed Callbacks

        /// <summary>
        /// 是否可显示清除按钮属性更改回调
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnCanShowClearButtonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchableTextBox stb = d as SearchableTextBox;
            if (stb == null || stb._btnClear == null)
            {
                return;
            }

            bool newValue = (bool)e.NewValue;
            if (!newValue)
            {
                stb._btnClear.Visibility = Visibility.Collapsed;
            }
            else if (stb._ttbInput != null && !string.IsNullOrEmpty(stb._ttbInput.Text))
            {
                stb._btnClear.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// 搜索条件更改回调
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnSearchTextPropretyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchableTextBox stb = d as SearchableTextBox;
            if (stb == null || !stb._canSearching)
            {
                return;
            }

            string searchKey = e.NewValue as string;
            if (string.IsNullOrEmpty(searchKey))//搜索关键字为空，不展示搜索popup
            {
                if (stb._popup != null)
                {
                    stb._popup.IsOpen = false;
                }

                return;
            }

            if (stb.SearchItemsSource == null || stb.SearchItemsSource.Count == 0)//搜索源为空，显示无搜索结果
            {
                if (stb._popup != null)
                {
                    stb._popup.IsOpen = true;
                }

                if (stb._lstSearchResult != null)
                {
                    stb._lstSearchResult.Visibility = Visibility.Collapsed;
                }

                return;
            }

            //根据关键字搜索匹配
            IList<SearchModel> searchResultList = null;
            if (stb.SearchMethod != null)
            {
                searchResultList = stb.SearchMethod(searchKey, stb.SearchItemsSource);
            }
            else
            {
                searchResultList = stb.DefaultSearch(searchKey, stb.SearchItemsSource);
            }

            lock (stb)
            {
                stb.SearchResultCollection.Clear();
                if (searchResultList != null && searchResultList.Count > 0)
                {
                    foreach (SearchModel sm in searchResultList)
                    {
                        stb.SearchResultCollection.Add(sm);
                    }
                }

                if (stb._popup != null)
                {
                    stb._popup.IsOpen = true;
                }

                if (stb._lstSearchResult != null)
                {
                    if (stb.SearchResultCollection.Count != 0)
                    {
                        stb._lstSearchResult.Visibility = Visibility.Visible;

                        //每次重新搜索，从头开始展示
                        VirtualizingPanel virtualizingPanel = stb._lstSearchResult.GetItemsHost() as VirtualizingPanel;
                        if (virtualizingPanel != null)
                        {
                            virtualizingPanel.CallEnsureGenerator();
                            virtualizingPanel.CallBringIndexIntoView(0);
                        }

                        ListBoxItem firstItem = (ListBoxItem)stb._lstSearchResult.ItemContainerGenerator.ContainerFromIndex(0);
                        if (null != firstItem)
                        {
                            firstItem.UpdateLayout();
                            firstItem.BringIntoView();
                        }
                    }
                    else
                    {
                        stb._lstSearchResult.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        #endregion

        #region Event Methods

        private void _ttbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(_ttbInput.Text))//输入为空，显示Tips，隐藏清除按钮
            {
                if (CanShowSearchTips && _ttbSearchTips != null)
                {
                    _ttbSearchTips.Visibility = Visibility;
                }

                if (CanShowClearButton && _btnClear != null)
                {
                    //是Hidden而不是Collapsed，因为需要控件占位
                    _btnClear.Visibility = Visibility.Hidden;
                }
            }
            else//输入不为空，隐藏Tips，显示清除按钮（如果允许）
            {
                if (_ttbSearchTips != null)
                {
                    _ttbSearchTips.Visibility = Visibility.Collapsed;
                }

                if (CanShowClearButton && _btnClear != null)
                {
                    _btnClear.Visibility = Visibility.Visible;
                }
            }
        }

        private void _btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (_ttbInput != null)
            {
                _ttbInput.Text = "";
            }
        }

        private void _lstSearchResult_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = LVTreeHelper.GetAncestor<ListBoxItem>((DependencyObject)e.OriginalSource);
            if (item == null)
            {
                return;
            }

            SetSelectedSearchItem(item.DataContext as SearchModel);
            _popup.IsOpen = false;
        }

        private void SearchableTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (_popup == null || !_popup.IsOpen
                || _lstSearchResult == null || _lstSearchResult.Items.Count == 0)
            {
                return;
            }

            if (e.Key == Key.Down)
            {
                if (_lstSearchResult.SelectedIndex < _lstSearchResult.Items.Count - 1)
                {
                    _lstSearchResult.SelectedIndex = _lstSearchResult.SelectedIndex == -1 ? 0 : _lstSearchResult.SelectedIndex + 1;
                    _lstSearchResult.ScrollIntoView(_lstSearchResult.SelectedItem);
                }
            }
            if (e.Key == Key.Up)
            {
                if (_lstSearchResult.SelectedIndex == -1 || _lstSearchResult.SelectedIndex == 0)
                {
                    _lstSearchResult.SelectedIndex = 0;
                }
                else
                {
                    _lstSearchResult.SelectedIndex = _lstSearchResult.SelectedIndex - 1;
                    _lstSearchResult.ScrollIntoView(_lstSearchResult.SelectedItem);
                }
            }
            if (e.Key == Key.Enter)
            {
                SetSelectedSearchItem(_lstSearchResult.SelectedItem as SearchModel);
                _popup.IsOpen = false;
            }

            e.Handled = true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 默认搜索方法
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private List<SearchModel> DefaultSearch(string searchKey, IList<SearchModel> source)
        {
            List<SearchModel> searchResultList = new List<SearchModel>();
            if (string.IsNullOrEmpty(searchKey) || source == null || source.Count == 0)
            {
                return searchResultList;
            }

            foreach (SearchModel sm in source)
            {
                if (sm.SearchField.Contains(searchKey))
                {
                    searchResultList.Add(sm);
                }
            }

            return searchResultList;
        }

        /// <summary>
        /// 设置选中的搜索结果项
        /// </summary>
        /// <param name="selectedItem"></param>
        private void SetSelectedSearchItem(SearchModel selectedSearchModel)
        {
            SelectedSearchItem = selectedSearchModel;

            RoutedEventArgs args = new RoutedEventArgs(SelectedSearchItemChangedEvent, this);
            RaiseEvent(args);

            if (selectedSearchModel == null)
            {
                return;
            }

            //更新搜索框显示内容为选中项
            _canSearching = false;
            SearchText = selectedSearchModel.Name;
            _canSearching = true;
        }

        #endregion

        #region Public Methods

        #endregion
    }
}

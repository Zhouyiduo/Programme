using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadInventoryUI.ViewModel
{
    public class BQRuleVM
    {

        public BQRuleVM()
        {

        }

        public BQRuleVM(
            string id, 
            string code, 
            string projectName,
            string operandRelate,
            string projectLCode
            )
        {
            ID = id;
            Code = code;
            ProjectName  = projectName;
            OperandRelate = operandRelate;
            ProjectLCode = projectLCode;
        }
        // 编码
        public string ID { get; set; }  
        // 清单编码
        public string Code { get; set; }
        // 项目名称
        public string ProjectName { get; set; }
        // 算量映射关系
        public string OperandRelate { get; set; }
        // 工程量代码
        public string ProjectLCode { get; set; }
    }
}

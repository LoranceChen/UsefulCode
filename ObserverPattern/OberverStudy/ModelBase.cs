using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OberverStudy
{
    public abstract class ModelBase
    {
        public ModelBase()
       {
       }
        /**//// <summary>
        /// 声明一个委托,用于代理一系列"无返回"及"不带参"的自定义方法
        /// </summary>
       public delegate void SubEventHandler(); 
        /**//// <summary>
        /// 声明一个绑定于上行所定义的委托的事件
        /// </summary>
        public event SubEventHandler SubEvent;
 
        /**//// <summary>
        /// 封装了触发事件的方法
        /// 主要为了规范化及安全性,除观察者基类外,其派生类不直接触发委托事件
        /// </summary>
        protected void Notify()
        {
            //提高执行效率及安全性
            if(this.SubEvent!=null)
                this.SubEvent();
                
       }
    }
}

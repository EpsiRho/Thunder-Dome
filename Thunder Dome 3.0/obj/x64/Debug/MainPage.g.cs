﻿#pragma checksum "C:\Users\jhset\source\repos\Thunder Dome 3.0\Thunder Dome 3.0\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DCAB0DDEB71E01B09C01EF83C014D35B2A77673B7A8EA3951022B897AD77BBAD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thunder_Dome_3._0
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TeachingTip_Target(global::Microsoft.UI.Xaml.Controls.TeachingTip obj, global::Windows.UI.Xaml.FrameworkElement value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Windows.UI.Xaml.FrameworkElement) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Windows.UI.Xaml.FrameworkElement), targetNullValue);
                }
                obj.Target = value;
            }
            public static void Set_Windows_UI_Xaml_Setter_Value(global::Windows.UI.Xaml.Setter obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Value = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_Primitives_RangeBase_Value(global::Windows.UI.Xaml.Controls.Primitives.RangeBase obj, global::System.Double value)
            {
                obj.Value = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj11_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::Thunder_Dome_3._0.Item dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj11;
            private global::Windows.UI.Xaml.Controls.TextBlock obj12;
            private global::Windows.UI.Xaml.Controls.ProgressBar obj13;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj12TextDisabled = false;
            private static bool isobj13ValueDisabled = false;

            public MainPage_obj11_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 129 && columnNumber == 36)
                {
                    isobj12TextDisabled = true;
                }
                else if (lineNumber == 131 && columnNumber == 97)
                {
                    isobj13ValueDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 11: // MainPage.xaml line 127
                        this.obj11 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 12: // MainPage.xaml line 129
                        this.obj12 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 13: // MainPage.xaml line 131
                        this.obj13 = (global::Windows.UI.Xaml.Controls.ProgressBar)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj11.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::Thunder_Dome_3._0.Item) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Thunder_Dome_3._0.Item)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Thunder_Dome_3._0.Item obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Name(obj.Name, phase);
                        this.Update_Progress(obj.Progress, phase);
                    }
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 129
                    if (!isobj12TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj12, obj, null);
                    }
                }
            }
            private void Update_Progress(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 131
                    if (!isobj13ValueDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_RangeBase_Value(this.obj13, obj);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj16_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::Thunder_Dome_3._0.Item dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj16;
            private global::Windows.UI.Xaml.Controls.TextBlock obj17;
            private global::Windows.UI.Xaml.Controls.ProgressBar obj18;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj17TextDisabled = false;
            private static bool isobj18ValueDisabled = false;

            private MainPage_obj16_BindingsTracking bindingsTracking;

            public MainPage_obj16_Bindings()
            {
                this.bindingsTracking = new MainPage_obj16_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 99 && columnNumber == 36)
                {
                    isobj17TextDisabled = true;
                }
                else if (lineNumber == 101 && columnNumber == 97)
                {
                    isobj18ValueDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 16: // MainPage.xaml line 97
                        this.obj16 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.StackPanel)target);
                        break;
                    case 17: // MainPage.xaml line 99
                        this.obj17 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 18: // MainPage.xaml line 101
                        this.obj18 = (global::Windows.UI.Xaml.Controls.ProgressBar)target;
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj16.Target as global::Windows.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::Thunder_Dome_3._0.Item) item, 1 << phase);
            }

            public void Recycle()
            {
                this.bindingsTracking.ReleaseAllListeners();
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Thunder_Dome_3._0.Item)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Thunder_Dome_3._0.Item obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Name(obj.Name, phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_Progress(obj.Progress, phase);
                    }
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 99
                    if (!isobj17TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj17, obj, null);
                    }
                }
            }
            private void Update_Progress(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // MainPage.xaml line 101
                    if (!isobj18ValueDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_RangeBase_Value(this.obj18, obj);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class MainPage_obj16_BindingsTracking
            {
                private global::System.WeakReference<MainPage_obj16_Bindings> weakRefToBindingObj; 

                public MainPage_obj16_BindingsTracking(MainPage_obj16_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<MainPage_obj16_Bindings>(obj);
                }

                public MainPage_obj16_Bindings TryGetBindingObject()
                {
                    MainPage_obj16_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                }

            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::Thunder_Dome_3._0.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.GridView obj2;
            private global::Windows.UI.Xaml.Controls.GridView obj3;
            private global::Microsoft.UI.Xaml.Controls.TeachingTip obj4;
            private global::Microsoft.UI.Xaml.Controls.TeachingTip obj5;
            private global::Windows.UI.Xaml.Setter obj14;
            private global::Windows.UI.Xaml.Setter obj19;
            private global::Windows.UI.Xaml.Controls.ProgressBar obj32;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;
            private static bool isobj3ItemsSourceDisabled = false;
            private static bool isobj4TargetDisabled = false;
            private static bool isobj5TargetDisabled = false;
            private static bool isobj14ValueDisabled = false;
            private static bool isobj19ValueDisabled = false;
            private static bool isobj32ValueDisabled = false;

            public MainPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 93 && columnNumber == 19)
                {
                    isobj2ItemsSourceDisabled = true;
                }
                else if (lineNumber == 123 && columnNumber == 58)
                {
                    isobj3ItemsSourceDisabled = true;
                }
                else if (lineNumber == 155 && columnNumber == 32)
                {
                    isobj4TargetDisabled = true;
                }
                else if (lineNumber == 166 && columnNumber == 32)
                {
                    isobj5TargetDisabled = true;
                }
                else if (lineNumber == 149 && columnNumber == 49)
                {
                    isobj14ValueDisabled = true;
                }
                else if (lineNumber == 119 && columnNumber == 49)
                {
                    isobj19ValueDisabled = true;
                }
                else if (lineNumber == 43 && columnNumber == 26)
                {
                    isobj32ValueDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // MainPage.xaml line 92
                        this.obj2 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        break;
                    case 3: // MainPage.xaml line 123
                        this.obj3 = (global::Windows.UI.Xaml.Controls.GridView)target;
                        break;
                    case 4: // MainPage.xaml line 153
                        this.obj4 = (global::Microsoft.UI.Xaml.Controls.TeachingTip)target;
                        break;
                    case 5: // MainPage.xaml line 164
                        this.obj5 = (global::Microsoft.UI.Xaml.Controls.TeachingTip)target;
                        break;
                    case 14: // MainPage.xaml line 149
                        this.obj14 = (global::Windows.UI.Xaml.Setter)target;
                        break;
                    case 19: // MainPage.xaml line 119
                        this.obj19 = (global::Windows.UI.Xaml.Setter)target;
                        break;
                    case 32: // MainPage.xaml line 40
                        this.obj32 = (global::Windows.UI.Xaml.Controls.ProgressBar)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::Thunder_Dome_3._0.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Thunder_Dome_3._0.MainPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                        this.Update_AddButton(obj.AddButton, phase);
                        this.Update_ChangeSize(obj.ChangeSize, phase);
                        this.Update_MainFontSize(obj.MainFontSize, phase);
                        this.Update_Speed(obj.Speed, phase);
                    }
                }
            }
            private void Update_ViewModel(global::Thunder_Dome_3._0.ItemsViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_ItemsLeft(obj.ItemsLeft, phase);
                        this.Update_ViewModel_ItemsRight(obj.ItemsRight, phase);
                    }
                }
            }
            private void Update_ViewModel_ItemsLeft(global::System.Collections.ObjectModel.ObservableCollection<global::Thunder_Dome_3._0.Item> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 92
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj2, obj, null);
                    }
                }
            }
            private void Update_ViewModel_ItemsRight(global::System.Collections.ObjectModel.ObservableCollection<global::Thunder_Dome_3._0.Item> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 123
                    if (!isobj3ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj3, obj, null);
                    }
                }
            }
            private void Update_AddButton(global::Windows.UI.Xaml.Controls.ListViewItem obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 153
                    if (!isobj4TargetDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TeachingTip_Target(this.obj4, obj, null);
                    }
                }
            }
            private void Update_ChangeSize(global::Windows.UI.Xaml.Controls.ListViewItem obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 164
                    if (!isobj5TargetDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TeachingTip_Target(this.obj5, obj, null);
                    }
                }
            }
            private void Update_MainFontSize(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 149
                    if (!isobj14ValueDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Setter_Value(this.obj14, obj, null);
                    }
                    // MainPage.xaml line 119
                    if (!isobj19ValueDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Setter_Value(this.obj19, obj, null);
                    }
                }
            }
            private void Update_Speed(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 40
                    if (!isobj32ValueDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_Primitives_RangeBase_Value(this.obj32, obj);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 92
                {
                    this.LeftItemGrid = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    ((global::Windows.UI.Xaml.Controls.GridView)this.LeftItemGrid).ItemClick += this.LeftItemGrid_ItemClick;
                    ((global::Windows.UI.Xaml.Controls.GridView)this.LeftItemGrid).RightTapped += this.LeftItemGrid_RightTapped;
                }
                break;
            case 3: // MainPage.xaml line 123
                {
                    this.RightItemGrid = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 4: // MainPage.xaml line 153
                {
                    this.AddItemPopup = (global::Microsoft.UI.Xaml.Controls.TeachingTip)(target);
                }
                break;
            case 5: // MainPage.xaml line 164
                {
                    this.FontChangePopup = (global::Microsoft.UI.Xaml.Controls.TeachingTip)(target);
                }
                break;
            case 6: // MainPage.xaml line 169
                {
                    this.FontChangeButtonDown = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.FontChangeButtonDown).Click += this.FontChangeButtonDown_Click;
                }
                break;
            case 7: // MainPage.xaml line 172
                {
                    this.FontChangeButtonUp = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.FontChangeButtonUp).Click += this.FontChangeButtonUp_Click;
                }
                break;
            case 8: // MainPage.xaml line 158
                {
                    this.AddItemTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.AddItemTextBox).KeyDown += this.AddButton_KeyDown;
                }
                break;
            case 9: // MainPage.xaml line 159
                {
                    this.AddItemPopupButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddItemPopupButton).Click += this.AddItemPopupButton_Click;
                }
                break;
            case 20: // MainPage.xaml line 36
                {
                    this.SpeedListShit = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 21: // MainPage.xaml line 59
                {
                    this.ActionList = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 22: // MainPage.xaml line 60
                {
                    this.PlayPauseButton = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                    ((global::Windows.UI.Xaml.Controls.ListViewItem)this.PlayPauseButton).Tapped += this.PlayPause_Tapped;
                }
                break;
            case 23: // MainPage.xaml line 66
                {
                    this.StopButton = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                    ((global::Windows.UI.Xaml.Controls.ListViewItem)this.StopButton).Tapped += this.StopButton_Tapped;
                }
                break;
            case 24: // MainPage.xaml line 72
                {
                    this.AddButton = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                    ((global::Windows.UI.Xaml.Controls.ListViewItem)this.AddButton).Tapped += this.AddButton_Tapped;
                }
                break;
            case 25: // MainPage.xaml line 78
                {
                    this.ChangeSize = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                    ((global::Windows.UI.Xaml.Controls.ListViewItem)this.ChangeSize).Tapped += this.FontChangeButtonDown_Click;
                    ((global::Windows.UI.Xaml.Controls.ListViewItem)this.ChangeSize).RightTapped += this.FontChangeButtonUp_Click;
                }
                break;
            case 26: // MainPage.xaml line 84
                {
                    this.TestButton = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                    ((global::Windows.UI.Xaml.Controls.ListViewItem)this.TestButton).Tapped += this.TestButton_Tapped;
                }
                break;
            case 27: // MainPage.xaml line 86
                {
                    this.Debug = (global::Windows.UI.Xaml.Controls.SymbolIcon)(target);
                }
                break;
            case 28: // MainPage.xaml line 74
                {
                    this.AddIcon = (global::Windows.UI.Xaml.Controls.SymbolIcon)(target);
                }
                break;
            case 29: // MainPage.xaml line 62
                {
                    this.PlayPauseIcon = (global::Windows.UI.Xaml.Controls.SymbolIcon)(target);
                }
                break;
            case 30: // MainPage.xaml line 63
                {
                    this.PlayPauseText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 31: // MainPage.xaml line 37
                {
                    this.SpeedIndicatorItem = (global::Windows.UI.Xaml.Controls.ListViewItem)(target);
                    ((global::Windows.UI.Xaml.Controls.ListViewItem)this.SpeedIndicatorItem).Tapped += this.SpeedIndicatorItem_Tapped;
                    ((global::Windows.UI.Xaml.Controls.ListViewItem)this.SpeedIndicatorItem).RightTapped += this.SpeedIndicatorItem_RightTapped;
                }
                break;
            case 32: // MainPage.xaml line 40
                {
                    this.SpeedBar = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 33: // MainPage.xaml line 53
                {
                    this.SpeedNumberText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            case 11: // MainPage.xaml line 127
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element11 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    MainPage_obj11_Bindings bindings = new MainPage_obj11_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element11.DataContext);
                    element11.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element11, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element11, bindings);
                }
                break;
            case 16: // MainPage.xaml line 97
                {                    
                    global::Windows.UI.Xaml.Controls.StackPanel element16 = (global::Windows.UI.Xaml.Controls.StackPanel)target;
                    MainPage_obj16_Bindings bindings = new MainPage_obj16_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element16.DataContext);
                    element16.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element16, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element16, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}


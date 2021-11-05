using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataGridGrouping.Models
{
    public class Task : INotifyPropertyChanged, IEditableObject
    {
        // Data for undoing canceled edits.
        private Task temp_Task = null;
        private bool m_Editing = false;

        // Public properties.
        private string _ProjectName = string.Empty;
        public string ProjectName
        {
            get { return this._ProjectName; }
            set => Set(ref _ProjectName, value);
        }

        private string _TaskName = string.Empty;
        public string TaskName
        {
            get { return this._TaskName; }
            set => Set(ref _TaskName, value);
        }

        private DateTime _DueDate = DateTime.Now;
        public DateTime DueDate
        {
            get { return this._DueDate; }
            set => Set(ref _DueDate, value);
        }

        private bool _Complete = false;
        public bool Complete
        {
            get { return this._Complete; }
            set => Set(ref _Complete, value);
        }

        // Implement IEditableObject interface.
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Task = MemberwiseClone() as Task;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                ProjectName = temp_Task.ProjectName;
                TaskName = temp_Task.TaskName;
                DueDate = temp_Task.DueDate;
                Complete = temp_Task.Complete;
                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Task = null;
                m_Editing = false;
            }
        }

        #region INotifyProperty
        // Implement INotifyPropertyChanged interface.

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
        #endregion

    }
}

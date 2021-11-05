using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataGridGrouping
{
    public class MainWindowViewModel
    {
        private ObservableCollection<Task> _MyTasks;
        public ObservableCollection<Task> MyTasks
        {
            get { return _MyTasks; }
            set => Set(ref _MyTasks, value);
        }

        public MainWindowViewModel()
        {
            GetTasks();
        }

        private void GetTasks()
        {
            MyTasks = new();
            for (int i = 1; i <= 44; i++)
            {
                MyTasks.Add(new Task()
                {
                    ProjectName = "Project " + ((i % 5) + 1).ToString(),
                    TaskName = "Task " + i.ToString(),
                    DueDate = DateTime.Now.AddDays(i),
                    Complete = (i % 2 == 0)
                });
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

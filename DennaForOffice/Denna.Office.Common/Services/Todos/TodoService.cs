using Denna.Office.Common.Data;
using Denna.Office.Common.Domain;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denna.Office.Common.Services.Todos
{
    public class TodoService
    {
        GenericRepository<Todo> repo;
        Realm _instance;
        public TodoService()
        {
            _instance = RealmContext.GetInstance();
            repo = new GenericRepository<Todo>(_instance);

        }
        #region CRUD
        public void AddTodo(Todo task)
        {
            task.Id = repo.CreateId();
            repo.Create(task);
        }

        public void AddSilentTodo(Todo task)
        {
            task.Id = repo.CreateId();
            repo.Create(task);
        }

        public IRealmCollection<Todo> GetAllTodos() => repo.GetAll();

        public Todo GetById(string id) => repo.GetById(id);

        public void Edit(Todo oldTask, Todo newTask)
        {
            repo.UpdatePrimary(newTask, newTask.Id);
        }


        public void Delete(string id)
        {
            repo.Delete(id);

        }

        public void Delete(Todo item)
        {
            repo.Delete(item.Id);

        }


        public void Done(Todo task)
        {
           
            using (var trans = _instance.BeginWrite())
            {
                task.Status = 0;
                trans.Commit();
            }

        }
        #endregion
        #region actions

        public void Undone(Todo task)
        {
            using (var trans = _instance.BeginWrite())
            {
                task.Status = 2;
                trans.Commit();
            }

            

        }

        public void Postpone(Todo task)
        {
            using (var trans = _instance.BeginWrite())
            {
                task.Status = 1;
                trans.Commit();
            }
        }
        #endregion
        #region Queries
        public IRealmCollection<Todo> GetTodayList()
        {
            var today = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0));
            return _instance.All<Todo>().Where(offset => offset.StartTime >= today).OrderBy(x => x.StartTime).AsRealmCollection();
        }

        public IRealmCollection<Todo> GetYesterdayList()
        {
            var yesterdayMorning = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, 0, 0, 0));
            var yesterdayEnd = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, 23, 59, 59));
            return _instance.All<Todo>().Where(offset => offset.StartTime >= yesterdayMorning && offset.StartTime <= yesterdayEnd).OrderBy(x => x.StartTime).AsRealmCollection();
        }

        public IRealmCollection<Todo> GetThisWeekList()
        {
            var today = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));
            var lastWeek = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-7).Day, 0, 0, 0));
            return _instance.All<Todo>().Where(offset => offset.StartTime >= lastWeek && offset.StartTime <= today).OrderBy(x => x.StartTime).AsRealmCollection();
        }

        public IRealmCollection<Todo> GetLastWeekList()
        {
            var lastWeekMorning = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-7).Day, 0, 0, 0));
            var twoWeeksAgoMorning = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-14).Day, 0, 0, 0));
            return _instance.All<Todo>().Where(offset => offset.StartTime >= lastWeekMorning && offset.StartTime <= twoWeeksAgoMorning).OrderBy(x => x.StartTime).AsRealmCollection();
        }

        public IRealmCollection<Todo> GetLastMonthList()
        {
            var lastMonthMorning = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, DateTime.Now.Day, 0, 0, 0));
            var endOfToday = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));
            var y = _instance.All<Todo>().Where(offset => offset.StartTime >= lastMonthMorning && offset.StartTime <= endOfToday).OrderBy(x => x.StartTime).AsRealmCollection();
            return y;
        }

        public IRealmCollection<Todo> GetPostponedList()
        {
            var today = new DateTimeOffset(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0));
            return _instance.All<Todo>().Where(s => (s.Status == 1 || s.Status == 2) && s.StartTime < today).OrderBy(x => x.StartTime).AsRealmCollection();
        }

        public IRealmCollection<Todo> GetMustDoList() => _instance.All<Todo>().Where(s => s.Status == 1 || s.Status == 2).OrderBy(x => x.StartTime).AsRealmCollection();

        public IRealmCollection<Todo> GetTodoListForDate(DateTimeOffset date)
        {
            var startDate = new DateTimeOffset(new DateTime(date.Year, date.Month, date.Day, 0, 0, 0));
            var endDate = new DateTimeOffset(new DateTime(date.Year, date.Month, date.Day, 23, 59, 59));
            return _instance.All<Todo>().Where(s => s.StartTime >= startDate && s.StartTime <= endDate).OrderBy(x => x.StartTime).AsRealmCollection();
        }

        public IRealmCollection<Todo> FullTextSearch(string term)
        {
            var itmz = _instance.All<Todo>().Where(s => s.Detail.Contains(term) || s.Subject.Contains(term)).OrderBy(x => x.StartTime).AsRealmCollection();
            return itmz;
        }
        #endregion
    }
}

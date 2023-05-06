using OptimalWeekApp.Models;
using OptimalWeekApp.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

public class EventStore : IDataStore<ITimeSpanEvent>
{
    private readonly SQLiteAsyncConnection _connection;
    private readonly string _db_path = "EventStore.db";

    public EventStore()
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _db_path);

        // temporary to delete the database on restart
        if (File.Exists(databasePath))
        {
            File.Delete(databasePath);
        }

        _connection = new SQLiteAsyncConnection(databasePath);
        _connection.CreateTableAsync<WeeklyEvent>().Wait();
    }

    public async Task<IEnumerable<ITimeSpanEvent>> GetEventsWeekday(string weekday)
    {
        WeekDay day;
        Enum.TryParse<WeekDay>(weekday, out day);

        return await _connection.Table<WeeklyEvent>().Where(e => e.Day == day).ToListAsync();
    }

    public async Task<bool> AddItemAsync(ITimeSpanEvent item)
    {
        if (item is WeeklyEvent weeklyEvent)
        {
            await _connection.InsertAsync(weeklyEvent);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> DeleteItemAsync(string id)
    {
        var item = await GetItemAsync(id);
        if (item != null)
        {
            await _connection.DeleteAsync(item);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<ITimeSpanEvent> GetItemAsync(string id)
    {
        return await _connection.FindAsync<WeeklyEvent>(id);
    }

    public async Task<IEnumerable<ITimeSpanEvent>> GetItemsAsync(bool forceRefresh = false)
    {
        return await _connection.Table<WeeklyEvent>().ToListAsync();
    }

    public async Task<bool> UpdateItemAsync(ITimeSpanEvent item)
    {
        if (item is WeeklyEvent weeklyEvent)
        {
            await _connection.UpdateAsync(weeklyEvent);
            return true;
        }
        else
        {
            return false;
        }
    }
}

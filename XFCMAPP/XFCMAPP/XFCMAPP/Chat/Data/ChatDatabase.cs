using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCMAPP.Chat.Models;

namespace XFCMAPP.Chat.Data
{
    public class ChatDatabase
    {
        private readonly SQLiteAsyncConnection dataBase;

        public ChatDatabase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);
            dataBase.CreateTableAsync<Message>().Wait();
        }

        public Task<List<Message>> GetMessagesAsync()
        {
            //Get all messages.
            return dataBase.Table<Message>().ToListAsync();
        }

        public Task<List<Message>> GetMessagesByChannelIdAsync(string channelId)
        {
            //Get all messages.
            return dataBase.Table<Message>().Where(x => x.ChannelId == channelId).OrderBy(o => o.CreatedDateTime).ToListAsync();
        }

        public Task<Message> GetMessageAsync(string id)
        {
            // Get a specific message.
            return dataBase.Table<Message>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> InsertMessageAsync(Message message)
        {
            // Save a new message.
            return dataBase.InsertAsync(message);
        }

        public Task<int> UpdateMessageAsync(Message message)
        {
            // Update an existing message.
            return dataBase.UpdateAsync(message);
        }

        public Task<int> DeleteMessageAsync(Message message)
        {
            // Delete a message.
            return dataBase.DeleteAsync(message);
        }

        public Task<int> DeleteAllMessageAsync()
        {
            // Delete all message.
            return dataBase.DeleteAllAsync<Message>();
        }
    }
}

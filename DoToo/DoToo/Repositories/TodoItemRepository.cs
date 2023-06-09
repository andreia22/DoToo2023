﻿using DoToo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


// comunicação direta com o BD, query para os bancos de dados 

namespace DoToo.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {

        private SQLiteAsyncConnection connection;

        private async Task CreateConnection()
        {
            if (connection != null)
                return;

            var documentPath =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments);

            var databasePath =
                Path.Combine(documentPath, "TodoItems.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<TodoItem>();
            // aqui poderiamos acicionar quantas tabelas existisem no modelo de nossa aplicação

            if(await connection.Table<TodoItem>().CountAsync() == 0 )
            {
                await connection.InsertAsync(
                    new TodoItem() {
                        Title = "Seja Bem Vindo",
                        Due = DateTime.Now
                    }
                );
            }
        }


        public event EventHandler<TodoItem> OnItemAdded;
        public event EventHandler<TodoItem> OnItemUpdate;

        public async  Task AddItem(TodoItem item)
        {
            await CreateConnection();
            await connection.InsertAsync( item );
            OnItemAdded?.Invoke(this, item);
        }

        public async Task AddOrUpdate(TodoItem item)
        {
            if(item.Id == 0)
            {
                await AddItem(item);

            }
            else
            {
                await UpdateItem(item)
;            }
        }

        public async Task<List<TodoItem>> GetItems()
        {
            await CreateConnection();
            return await connection.Table<TodoItem>()
                            .ToListAsync();

        }

        public async Task UpdateItem(TodoItem item)
        {
            await CreateConnection();
            await connection.UpdateAsync( item );
            OnItemUpdate?.Invoke(this, item);

        }
    }
}

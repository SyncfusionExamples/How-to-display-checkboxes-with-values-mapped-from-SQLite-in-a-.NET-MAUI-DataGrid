﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using SQLite;
using SQLitePCL;

namespace SfDataGridSample
{
    public class SampleDemoDatabase 
    {
        private ObservableCollection<OrderItem> orderItemsDataSource;
        public ObservableCollection<OrderItem> OrderItemsDataSource
        {
            get => this.orderItemsDataSource;
            set
            {
                this.orderItemsDataSource = value;
                
            }
        }
        SQLiteConnection database;

        public const string DatabaseFilename = "TestDataBases.db3";
       
        public SampleDemoDatabase()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

            // Get the SQLite database connection
            database = new SQLiteConnection(dbPath);

            // Create the table if it doesn't exist
            database.CreateTable<OrderItem>();

            // Insert sample data into the database
            InsertSampleData();

            // Get the sample data from the database
            GetItems();

        }

        public void InsertSampleData()
        {
            // Sample data
            var sampleItems = new List<OrderItem>
            {
                new OrderItem { OrderID = 1001, Name = "Patient01", TokenNo = 1501, BillStatus = "PAID", Count = 1 },
                new OrderItem { OrderID = 1002, Name = "Patient02", TokenNo = 1502, BillStatus = "NOT PAID", Count = 0 },
                new OrderItem { OrderID = 1003, Name = "Patient03", TokenNo = 1503, BillStatus = "PAID", Count = 1 },
                // Add more sample items as needed
            };

            foreach (var item in sampleItems)
            {
                try
                {
                    database.Insert(item);
                }
                catch (SQLiteException ex)
                {
                    // Handle exceptions, e.g., duplicate insertions
                    Console.WriteLine($"SQLiteException: {ex.Message}");
                }
            }
        }

        public void GetItems()
        {
                var table = database.Table<OrderItem>().ToList();
                OrderItemsDataSource= new ObservableCollection<OrderItem>(table);
        }
    }
}

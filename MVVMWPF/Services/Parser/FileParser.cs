﻿using Microsoft.Win32;
using MVVMWPF.Model;
using System;
using System.Collections.Generic;
using System.Data;


namespace MVVMWPF.Services
{
    /// <summary>
    /// Класс реализующий парсинг файла в коллекцию.
    /// </summary>
    internal class FileParser
    {
        private OpenFileDialog openFileDialog;
        /// <summary>
        /// Поле, содержащее текущую стратегию парсинга файла.
        /// </summary>
        public IParser ParseStrategy { private get; set; }

        public FileParser()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
        }
        /// <summary>
        /// Метод, создающий диалоговое окно выбора файла, а также запускающий реализацию текущей стратегии парсинга из ParseStrategy.
        /// </summary>
        /// <returns>Возвращает интерфейсную ссылку IEnumerable</returns>
        public IEnumerable<T> GetData<T>()
        {
            IEnumerable<T> data;
            ParseStrategy.SetupFileDialog(openFileDialog);
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                data = ParseStrategy.GetData<T>(filePath);
                return data;
            }
            return null;
        }
    }
}


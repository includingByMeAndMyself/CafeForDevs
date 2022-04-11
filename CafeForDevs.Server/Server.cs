﻿using CafeForDevs.Models;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CafeForDevs.Server
{
    internal class Server
    {
        private readonly HttpListener _httpListener;
        private readonly Router _router;

        public Server(HttpListener httpListener, Router router)
        {
            _httpListener = httpListener;
            _router = router;
        }

        internal void Start()
        {
            Console.WriteLine("Server started");
            _httpListener.Start();

            try
            {
                while (true)
                {
                    var context = _httpListener.GetContext();

                    var path = context.Request.Url.PathAndQuery;

                    var handler = _router.Get(path);
                    handler.Handle(context);

                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("serverLogs.log", ex.ToString());
            }
            finally
            {
                _httpListener.Stop();
            }   
        }
    }
}

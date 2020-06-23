﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarfaceAuth
{
    public class Process_Start
    {
        public Random HWID_Random = new Random();
        public void Start_Game(string uid,string token,string shard_id,string server,string dir)
        {
            Process exe = new Process();
            exe.StartInfo.FileName = dir;
            exe.StartInfo.Arguments = $" -region_id global --shard_id={shard_id} -onlineserver {server} -uid {uid} -token {token}";
            exe.Start();
        }
        public void Start_Bot(string uid,string token,string server,string dir)
        {
            string bot_server = "./cfg/server/ru-alpha.cfg";
            if(server == "s1.warface.ru")
            {
                bot_server = "./cfg/server/ru-alpha.cfg";
            }
            if (server == "s2.warface.ru")
            {
                bot_server = "./cfg/server/ru-bravo.cfg";
            }
            if (server == "s3.warface.ru")
            {
                bot_server = "./cfg/server/ru-charlie.cfg";
            }
            if (server == "s12.warface.ru")
            {
                bot_server = "./cfg/server/ru-delta.cfg";
            }
            ProcessStartInfo exe = new ProcessStartInfo();
            exe.FileName = "C:/windows/system32/cmd.exe";
            exe.Arguments = $"/c cd /d {Program.exe_dir}" +
                $" & chcp 65001" +
                $" & wb.exe" +
                $" --id {uid}" +
                $" --token {token}" +
                $" -f {bot_server}" +
                $" -d game_hwid={Generate_random_hwid()}";
            Process.Start(exe);
        }
        public int Generate_random_hwid()
        {
            int New_Hwid = HWID_Random.Next(100000000, 999999999);
            return New_Hwid;
        }
    }
}

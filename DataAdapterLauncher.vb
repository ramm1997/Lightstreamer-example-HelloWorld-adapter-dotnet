﻿'
' Copyright 2013 Weswit Srl
'
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
'
' http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions and
' limitations under the License.
'

Imports System.Net.Sockets

Imports Lightstreamer.DotNet.Server

Module Module1
    Sub Main()
        Dim host As String = "localhost"
        Dim reqrepPort As Integer = 6661
        Dim notifPort As Integer = 6662

        Try
            Dim server As New DataProviderServer()
            server.Adapter = New HelloWorldAdapter()

            Dim reqrepSocket As New TcpClient(host, reqrepPort)
            server.RequestStream = reqrepSocket.GetStream()
            server.ReplyStream = reqrepSocket.GetStream()

            Dim notifSocket As New TcpClient(host, notifPort)
            server.NotifyStream = notifSocket.GetStream()

            server.Start()
            System.Console.WriteLine("Remote Adapter connected to Lightstreamer Server.")
            System.Console.WriteLine("Ready to publish data...")
        Catch e As Exception
            System.Console.WriteLine("Could not connect to Lightstreamer Server.")
            System.Console.WriteLine("Make sure Lightstreamer Server is started before this Adapter.")
            System.Console.WriteLine(e)
        End Try
    End Sub
End Module

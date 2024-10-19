﻿//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort And Peace
//==================================================

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;

//var aDotNetClient = new ADotNetClient();

var githubPipeline = new GithubPipeline
{
    Name = "Projecgt Build Pipeline",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "main" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "main" }
        }
    },

    Jobs = new Dictionary<string, Job>
    {
        {
            "build",
            new Job
            {
                RunsOn = BuildMachines.Windows2022,

                Steps = new List<GithubTask>
                {
                    new CheckoutTaskV2
                    {
                        Name = "Check out"
                    },

                    new SetupDotNetTaskV1
                    {
                        Name = "Setup .Net",

                        TargetDotNetVersion = new TargetDotNetVersion
                        {
                            DotNetVersion = "6.0.427",
                            
                        }
                    },

                    new RestoreTask
                    {
                        Name = "Restore nuget packages"
                    },

                    new DotNetBuildTask
                    {
                        Name = "Building project"
                    },

                    new TestTask
                    {
                        Name = "Running Tests"
                    }
                }
            }
        }
    }
};

var client= new ADotNetClient();
client.SerializeAndWriteToFile(adoPipeline: githubPipeline,
    path: "../../../../.github/workflows/dotnet.yml");

//string buildScriptPath = "../../../../.github/workflows/dotnet.yml";
//string directoryPath = Path.GetDirectoryName(buildScriptPath);

//if (!Directory.Exists(directoryPath))
//{
//    Directory.CreateDirectory(directoryPath);
//}

//aDotNetClient.SerializeAndWriteToFile(githubPipeline, path: buildScriptPath);
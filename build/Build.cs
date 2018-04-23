using System;
using System.IO;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;

class Build : NukeBuild
{
    // Console application entry. Also defines the default target.
    public static int Main () => Execute<Build>(x => x.Compile);

    // Auto-injection fields:

    [GitVersion] readonly GitVersion GitVersion;
    // Semantic versioning. Must have 'GitVersion.CommandLine' referenced.

    [GitRepository] readonly GitRepository GitRepository;
    // Parses origin, branch name and head from git config.

    // [Parameter] readonly string MyGetApiKey;
    // Returns command-line arguments and environment variables.

    Target Clean => _ => _
            //.OnlyWhen(() => false) // Disabled for safety.
            .Executes(() =>
            {
                try
                {
                    // note: 當 Visual Studio 已經開啟應用程式專案，以下刪除操作會因為目錄被鎖住而失敗。
                    DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));
                }
                catch (Exception ex)
                {
                    Logger.Error($"刪除原始碼目錄下的 **/bin 和 **/obj 時發生錯誤: {ex.Message}");
                }
                EnsureCleanDirectory(OutputDirectory);
            });

    Target Restore => _ => _
            .DependsOn(Clean)
            .Executes(() =>
            {
                MSBuild(s => DefaultMSBuildRestore);
            });

    Target Compile => _ => _
            .DependsOn(Restore)
            .Requires(() => GitVersion != null)
            .Executes(() =>
            {
                //GitVersionTasks.DefaultGitVersion.EnableUpdateAssemblyInfo();

                MSBuild(s => DefaultMSBuildCompile);

                string outputDir = OutputDirectory / "net452";

                if (GitRepository.Branch.Equals(Shared.ProductBranches.TaipeiForBlind, StringComparison.CurrentCultureIgnoreCase))
                {
                    string srcFileName = Path.Combine(outputDir, "AppConfig.ForBlind.ini");
                    string dstFileName = Path.Combine(outputDir, "AppConfig.Default.ini");

                    Logger.Info(Environment.NewLine + "**********<<< 額外處理 >>>****************");
                    Logger.Info($"使用特定分支版本的預設應用程式組態檔：'{Shared.ProductBranches.TaipeiForBlind}'");
                    File.Copy(srcFileName, dstFileName, true);
                    File.Delete(srcFileName);

                    // Removing unnecessary files.
                    var dir = new DirectoryInfo(outputDir);
                    foreach (var file in dir.EnumerateFiles("*.pdb"))
                    {
                        file.Delete();
                    }
                }
            });
}

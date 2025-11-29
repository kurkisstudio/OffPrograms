using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;
using System.Threading.Tasks;

namespace OffPrograms
{
    public partial class MainForm : Form
    {
        private Button btnRemoveEdge;
        private Button btnToggleDefender;
        private Button btnUninstallProgram;
        private TextBox txtProgramName;
        private Button btnCleanTemp;
        private Button btnDisableUpdates;
        private Button btnEnableUpdates;
        private Button btnRestorePoint;
        private Button btnDefrag;
        private Button btnDiskCleanup;
        private Button btnSystemRestore;
        private Label lblProgramName;
        private Label lblTitle;
        private Label lblStatus;

        public MainForm()
        {
            InitializeComponent();
            CheckAdminStatus();
        }

        private void CheckAdminStatus()
        {
            try
            {
                using (var identity = System.Security.Principal.WindowsIdentity.GetCurrent())
                {
                    var principal = new System.Security.Principal.WindowsPrincipal(identity);
                    bool isAdmin = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
                    
                    if (!isAdmin)
                    {
                        lblStatus.Text = "⚠️ Запустите от Администратора!";
                        lblStatus.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblStatus.Text = "✅ Запущено с правами Администратора";
                        lblStatus.ForeColor = Color.Green;
                    }
                }
            }
            catch
            {
                lblStatus.Text = "❓ Не удалось проверить права";
                lblStatus.ForeColor = Color.Orange;
            }
        }

        private void InitializeComponent()
        {
            this.btnRemoveEdge = new Button();
            this.btnToggleDefender = new Button();
            this.btnUninstallProgram = new Button();
            this.txtProgramName = new TextBox();
            this.btnCleanTemp = new Button();
            this.btnDisableUpdates = new Button();
            this.btnEnableUpdates = new Button();
            this.btnRestorePoint = new Button();
            this.btnDefrag = new Button();
            this.btnDiskCleanup = new Button();
            this.btnSystemRestore = new Button();
            this.lblProgramName = new Label();
            this.lblTitle = new Label();
            this.lblStatus = new Label();

            // Настройка формы
            this.SuspendLayout();
            this.Text = "OffPrograms - Системные утилиты v2.0";
            this.Size = new Size(420, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Заголовок
            this.lblTitle.Location = new Point(20, 10);
            this.lblTitle.Size = new Size(380, 25);
            this.lblTitle.Text = "OffPrograms - Системные утилиты v2.0";
            this.lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Статус прав
            this.lblStatus.Location = new Point(20, 40);
            this.lblStatus.Size = new Size(380, 20);
            this.lblStatus.Text = "Проверка прав...";
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            this.lblStatus.Font = new Font("Arial", 9, FontStyle.Bold);

            // Кнопка удаления Edge
            this.btnRemoveEdge.Location = new Point(20, 70);
            this.btnRemoveEdge.Size = new Size(380, 30);
            this.btnRemoveEdge.Text = "🗑️ Удалить Microsoft Edge (Агрессивно)";
            this.btnRemoveEdge.BackColor = Color.LightCoral;
            this.btnRemoveEdge.Click += new EventHandler(this.btnRemoveEdge_Click);

            // Кнопка Windows Defender
            this.btnToggleDefender.Location = new Point(20, 105);
            this.btnToggleDefender.Size = new Size(380, 30);
            this.btnToggleDefender.Text = "🛡️ Включить/Выключить Windows Defender";
            this.btnToggleDefender.BackColor = Color.LightYellow;
            this.btnToggleDefender.Click += new EventHandler(this.btnToggleDefender_Click);

            // Поле для ввода названия программы
            this.lblProgramName.Location = new Point(20, 145);
            this.lblProgramName.Size = new Size(380, 20);
            this.lblProgramName.Text = "Название программы для удаления:";
            this.lblProgramName.Font = new Font("Arial", 9);

            this.txtProgramName.Location = new Point(20, 165);
            this.txtProgramName.Size = new Size(380, 25);
            this.txtProgramName.Text = "";
            this.txtProgramName.Font = new Font("Arial", 9);

            // Кнопка удаления программы
            this.btnUninstallProgram.Location = new Point(20, 195);
            this.btnUninstallProgram.Size = new Size(380, 30);
            this.btnUninstallProgram.Text = "❌ Удалить программу";
            this.btnUninstallProgram.BackColor = Color.LightCoral;
            this.btnUninstallProgram.Click += new EventHandler(this.btnUninstallProgram_Click);

            // Кнопка очистки временных файлов
            this.btnCleanTemp.Location = new Point(20, 230);
            this.btnCleanTemp.Size = new Size(380, 30);
            this.btnCleanTemp.Text = "🧹 Очистить временные файлы";
            this.btnCleanTemp.BackColor = Color.LightGreen;
            this.btnCleanTemp.Click += new EventHandler(this.btnCleanTemp_Click);

            // Кнопка отключения обновлений
            this.btnDisableUpdates.Location = new Point(20, 265);
            this.btnDisableUpdates.Size = new Size(185, 30);
            this.btnDisableUpdates.Text = "⛔ Выкл. обновления";
            this.btnDisableUpdates.BackColor = Color.LightCoral;
            this.btnDisableUpdates.Click += new EventHandler(this.btnDisableUpdates_Click);

            // Кнопка включения обновлений
            this.btnEnableUpdates.Location = new Point(215, 265);
            this.btnEnableUpdates.Size = new Size(185, 30);
            this.btnEnableUpdates.Text = "✅ Вкл. обновления";
            this.btnEnableUpdates.BackColor = Color.LightGreen;
            this.btnEnableUpdates.Click += new EventHandler(this.btnEnableUpdates_Click);

            // Кнопка создания точки восстановления
            this.btnRestorePoint.Location = new Point(20, 300);
            this.btnRestorePoint.Size = new Size(185, 30);
            this.btnRestorePoint.Text = "💾 Точка восстановления";
            this.btnRestorePoint.BackColor = Color.LightBlue;
            this.btnRestorePoint.Click += new EventHandler(this.btnRestorePoint_Click);

            // Кнопка восстановления системы
            this.btnSystemRestore.Location = new Point(215, 300);
            this.btnSystemRestore.Size = new Size(185, 30);
            this.btnSystemRestore.Text = "🔧 Восстановление";
            this.btnSystemRestore.BackColor = Color.LightBlue;
            this.btnSystemRestore.Click += new EventHandler(this.btnSystemRestore_Click);

            // Кнопка дефрагментации
            this.btnDefrag.Location = new Point(20, 335);
            this.btnDefrag.Size = new Size(185, 30);
            this.btnDefrag.Text = "⚙️ Оптимизация диска";
            this.btnDefrag.BackColor = Color.LightGray;
            this.btnDefrag.Click += new EventHandler(this.btnDefrag_Click);

            // Кнопка очистки диска
            this.btnDiskCleanup.Location = new Point(215, 335);
            this.btnDiskCleanup.Size = new Size(185, 30);
            this.btnDiskCleanup.Text = "🧽 Очистка диска";
            this.btnDiskCleanup.BackColor = Color.LightGreen;
            this.btnDiskCleanup.Click += new EventHandler(this.btnDiskCleanup_Click);

            // Добавление элементов на форму
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRemoveEdge);
            this.Controls.Add(this.btnToggleDefender);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.txtProgramName);
            this.Controls.Add(this.btnUninstallProgram);
            this.Controls.Add(this.btnCleanTemp);
            this.Controls.Add(this.btnDisableUpdates);
            this.Controls.Add(this.btnEnableUpdates);
            this.Controls.Add(this.btnRestorePoint);
            this.Controls.Add(this.btnSystemRestore);
            this.Controls.Add(this.btnDefrag);
            this.Controls.Add(this.btnDiskCleanup);

            this.ResumeLayout(false);
        }

        // Удаление Edge - максимально агрессивно
        private async void btnRemoveEdge_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "🚨 АГРЕССИВНОЕ УДАЛЕНИЕ EDGE!\n\n" +
                    "⚠️  Это удалит Edge полностью\n" +
                    "⚠️  Могут сломаться системные функции\n" +
                    "⚠️  Требуется перезагрузка\n\n" +
                    "Продолжить?",
                    "КРИТИЧЕСКОЕ ПРЕДУПРЕЖДЕНИЕ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    btnRemoveEdge.Enabled = false;
                    btnRemoveEdge.Text = "🔄 Удаляем Edge...";

                    string[] commands = {
                        "powershell -Command \"Get-AppxPackage -AllUsers *Edge* | Remove-AppxPackage -ErrorAction SilentlyContinue\"",
                        "powershell -Command \"Get-AppxProvisionedPackage -Online | Where-Object {$_.PackageName -like '*Edge*'} | Remove-AppxProvisionedPackage -Online -ErrorAction SilentlyContinue\"",
                        "winget uninstall Microsoft.Edge --silent --accept-source-agreements --disable-interactivity --force",
                        "rd /s /q \"C:\\Program Files (x86)\\Microsoft\\Edge\" 2>nul",
                        "rd /s /q \"C:\\Program Files\\Microsoft\\Edge\" 2>nul",
                        "rd /s /q \"%LocalAppData%\\Microsoft\\Edge\" 2>nul",
                        "reg delete \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Microsoft Edge\" /f 2>nul",
                        "reg delete \"HKLM\\SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Microsoft Edge\" /f 2>nul",
                        "reg delete \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\msedge.exe\" /f 2>nul",
                        "reg add \"HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Communications\" /v ConfigureChatAutoInstall /t REG_DWORD /d 0 /f",
                        "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\EdgeUpdate\" /v AllowInstallation /t REG_DWORD /d 0 /f"
                    };

                    int successCount = 0;
                    foreach (string command in commands)
                    {
                        try
                        {
                            if (await ExecuteCommandAsync(command))
                                successCount++;
                            await Task.Delay(1000);
                        }
                        catch { }
                    }

                    btnRemoveEdge.Enabled = true;
                    btnRemoveEdge.Text = "🗑️ Удалить Microsoft Edge (Агрессивно)";

                    MessageBox.Show($"Edge удален! Выполнено команд: {successCount}/{commands.Length}\n\n" +
                                  "🔁 ОБЯЗАТЕЛЬНО ПЕРЕЗАГРУЗИТЕ КОМПЬЮТЕР!",
                                  "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                btnRemoveEdge.Enabled = true;
                btnRemoveEdge.Text = "🗑️ Удалить Microsoft Edge (Агрессивно)";
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Windows Defender - улучшенные методы
        private async void btnToggleDefender_Click(object sender, EventArgs e)
        {
            try
            {
                bool isEnabled = await IsDefenderEnabledAsync();
                string status = isEnabled ? "отключить" : "включить";
                
                DialogResult result = MessageBox.Show(
                    $"Вы уверены, что хотите {status} Windows Defender?\n" +
                    "Это критическое изменение системы!\n" +
                    "Требуется перезагрузка.",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    btnToggleDefender.Enabled = false;
                    btnToggleDefender.Text = "🔄 Работаем...";

                    if (isEnabled)
                    {
                        string[] disableCommands = {
                            "net stop WinDefend /y",
                            "net stop WdNisSvc /y", 
                            "net stop Sense /y",
                            "sc config WinDefend start= disabled",
                            "sc config WdNisSvc start= disabled", 
                            "sc config Sense start= disabled",
                            "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\" /v DisableAntiSpyware /t REG_DWORD /d 1 /f",
                            "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\" /v DisableAntiVirus /t REG_DWORD /d 1 /f",
                            "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection\" /v DisableRealtimeMonitoring /t REG_DWORD /d 1 /f"
                        };

                        foreach (string cmd in disableCommands)
                        {
                            await ExecuteCommandAsync(cmd);
                            await Task.Delay(500);
                        }
                    }
                    else
                    {
                        string[] enableCommands = {
                            "sc config WinDefend start= auto",
                            "sc config WdNisSvc start= auto", 
                            "sc config Sense start= auto",
                            "net start WinDefend",
                            "net start WdNisSvc",
                            "net start Sense",
                            "reg delete \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\" /v DisableAntiSpyware /f 2>nul",
                            "reg delete \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\" /v DisableAntiVirus /f 2>nul",
                            "reg delete \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Real-Time Protection\" /v DisableRealtimeMonitoring /f 2>nul"
                        };

                        foreach (string cmd in enableCommands)
                        {
                            await ExecuteCommandAsync(cmd);
                            await Task.Delay(500);
                        }
                    }

                    btnToggleDefender.Enabled = true;
                    btnToggleDefender.Text = "🛡️ Включить/Выключить Windows Defender";

                    MessageBox.Show($"Windows Defender {status}!\n\n" +
                                  "🔄 ПЕРЕЗАГРУЗИТЕ КОМПЬЮТЕР ДЛЯ ПРИМЕНЕНИЯ ИЗМЕНЕНИЙ!",
                                  "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                btnToggleDefender.Enabled = true;
                btnToggleDefender.Text = "🛡️ Включить/Выключить Windows Defender";
                MessageBox.Show($"Ошибка: {ex.Message}\n\nЗапустите программу от администратора.", 
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удаление выбранной программы
        private async void btnUninstallProgram_Click(object sender, EventArgs e)
        {
            try
            {
                string programName = txtProgramName.Text.Trim();
                if (string.IsNullOrEmpty(programName))
                {
                    MessageBox.Show("Введите название программы для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить программу содержащую '{programName}'?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string command = $"wmic product where \"name like '%{programName}%'\" call uninstall /nointeractive";
                    await ExecuteCommandAsync(command);
                    
                    string psCommand = $"powershell -Command \"Get-WmiObject -Class Win32_Product | Where-Object {{$_.Name -like '*{programName}*'}} | ForEach-Object {{$_.Uninstall()}}\"";
                    await ExecuteCommandAsync(psCommand);

                    MessageBox.Show($"Команды для удаления '{programName}' выполнены!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Очистка временных файлов
        private async void btnCleanTemp_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Очистить временные файлы системы? Это освободит место на диске.",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int deletedFiles = 0;
                    
                    string tempPath = Path.GetTempPath();
                    CleanDirectory(tempPath, ref deletedFiles);
                    
                    string winTempPath = @"C:\Windows\Temp";
                    if (Directory.Exists(winTempPath))
                    {
                        CleanDirectory(winTempPath, ref deletedFiles);
                    }
                    
                    await ExecuteCommandAsync("cleanmgr /sagerun:1");

                    MessageBox.Show($"Временные файлы очищены!\nОсвобождено место для {deletedFiles} файлов.", 
                        "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Отключение обновлений Windows
        private async void btnDisableUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Отключить автоматические обновления Windows?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    await ExecuteCommandAsync("sc config wuauserv start= disabled");
                    await ExecuteCommandAsync("net stop wuauserv");
                    await ExecuteCommandAsync("sc config bits start= disabled");
                    await ExecuteCommandAsync("net stop bits");
                    
                    try
                    {
                        using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"))
                        {
                            key.SetValue("NoAutoUpdate", 1, RegistryValueKind.DWord);
                        }
                    }
                    catch { }

                    MessageBox.Show("Автообновления отключены!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Включение обновлений Windows
        private async void btnEnableUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Включить автоматические обновления Windows?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await ExecuteCommandAsync("sc config wuauserv start= auto");
                    await ExecuteCommandAsync("net start wuauserv");
                    await ExecuteCommandAsync("sc config bits start= auto");
                    await ExecuteCommandAsync("net start bits");
                    
                    try
                    {
                        using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU"))
                        {
                            key.SetValue("NoAutoUpdate", 0, RegistryValueKind.DWord);
                        }
                    }
                    catch { }

                    MessageBox.Show("Автообновления включены!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Создание точки восстановления
        private async void btnRestorePoint_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Создать точку восстановления системы?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string command = "powershell -Command \"Checkpoint-Computer -Description 'OffPrograms_Restore_Point' -RestorePointType 'MODIFY_SETTINGS'\"";
                    await ExecuteCommandAsync(command);
                    MessageBox.Show("Точка восстановления создана!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Дефрагментация диска
        private async void btnDefrag_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Запустить оптимизацию диска C:?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await ExecuteCommandAsync("defrag C: /O /U /V");
                    MessageBox.Show("Оптимизация диска запущена!\nЭто может занять некоторое время.", 
                        "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Очистка диска
        private async void btnDiskCleanup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Запустить очистку диска?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await ExecuteCommandAsync("cleanmgr /sagerun:1");
                    MessageBox.Show("Очистка диска запущена!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Восстановление системы
        private void btnSystemRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Открыть восстановление системы?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ExecuteCommand("rstrui.exe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательные методы
        private async Task<bool> ExecuteCommandAsync(string command)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C {command}";
                startInfo.Verb = "runas";
                startInfo.UseShellExecute = true;
                startInfo.CreateNoWindow = true;
                process.StartInfo = startInfo;
                
                process.Start();
                await Task.Run(() => process.WaitForExit(15000));
                
                return process.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        private void ExecuteCommand(string command)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/C {command}";
                startInfo.Verb = "runas";
                startInfo.UseShellExecute = true;
                process.StartInfo = startInfo;
                process.Start();
            }
            catch { }
        }

        private void CleanDirectory(string path, ref int counter)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                
                foreach (FileInfo file in di.GetFiles())
                {
                    try 
                    { 
                        file.Delete();
                        counter++;
                    }
                    catch { }
                }
                
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try 
                    { 
                        dir.Delete(true);
                        counter++;
                    }
                    catch { }
                }
            }
            catch { }
        }

        private async Task<bool> IsDefenderEnabledAsync()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows Defender\Real-Time Protection"))
                {
                    if (key != null)
                    {
                        var value = key.GetValue("DisableRealtimeMonitoring");
                        return value == null || (int)value == 0;
                    }
                }
            }
            catch { }
            return true;
        }
    }

    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
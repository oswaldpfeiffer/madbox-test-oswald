using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger : BaseService<ILogger>, ILogger
{
    [SerializeField] private ELogLevel _editorLogLevel;
    [SerializeField] private ELogLevel _buildLogLevel;

    [SerializeField] private bool _editorWriteLogsToFile;
    [SerializeField] private bool _buildWriteLogsToFile;

    private ELogLevel _appLogLevel = ELogLevel.Info;
    private bool _writeLogsToFile = true;

    private void Start()
    {
#if UNITY_EDITOR
        SetAppLogLevel(_editorLogLevel);
        SetAppWriteToFileState(_editorWriteLogsToFile);
#else
        SetAppLogLevel(_buildLogLevel);
        SetAppWriteToFileState(_buildWriteLogsToFile);
#endif
    }

    private void SetAppLogLevel (ELogLevel level)
    {
        _appLogLevel = level;
    }

    private void SetAppWriteToFileState (bool canWrite)
    {
        _writeLogsToFile = canWrite;
    }

    public void Log(string message, ELogLevel level = ELogLevel.Info)
    {
        if (_appLogLevel > level || _appLogLevel == ELogLevel.None) return;

        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        Debug.Log(logMessage);

        if (_writeLogsToFile)
        {
            using StreamWriter writer = new StreamWriter("log.txt", true);
            writer.WriteLine(logMessage);
        }
    }
}

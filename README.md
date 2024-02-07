# LogCompressor

This application, LogCompressor, is designed to compress log files by filtering out specific lines containing predefined error keywords. It provides a user-friendly interface for selecting source and destination directories and allows users to specify error keywords for filtering.

## Usage

1. **Select Source Directory**: Click on the "Source folder" button to choose the source directory containing the log files you want to compress.

2. **Select Destination Directory**: Click on the "Destination folder" button to specify the destination directory where the compressed log file will be saved.

3. **Add Error Keywords**: Enter error keywords in the provided text box and click on the "Add keyword" button to add them to the list. These keywords will be used to filter log files.

4. **Remove Error Keywords**: Select a keyword from the list and click on the "Remove keyword" button to remove it.

5. **Compress Log Files**: After specifying the source, destination, and error keywords, click on the "Create" button to start compressing log files. The application will search through all files in the selected source directory, filter out lines containing error keywords, and save the compressed output in the specified destination directory.

6. **Exit Application**: Click on the "Close" button to exit the application.

## Requirements

- This application requires the Windows Presentation Foundation (WPF) framework.
- Make sure the Microsoft WindowsAPICodePack library is included in the project for utilizing the CommonOpenFileDialog class.

## Notes

- The application searches all files in the selected source directory, regardless of their file extensions.
- Error keywords are case-sensitive. Ensure that the keywords are entered correctly for accurate filtering.
- The compressed output file will be named "CompressedOutput.txt" and will contain the filtered lines from the log files.
- Each line containing an error keyword will be prefixed with "Found:" in the output file.
- A separator line consisting of 50 dashes ("-") will be inserted between entries for better readability.
- Ensure that proper file permissions are set for reading files from the source directory and writing the compressed output file to the destination directory.

## License

This project is licensed under the [MIT License](LICENSE).

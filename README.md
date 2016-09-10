# MatiAplikacja

Application is used to counting from three years to zero. Countdown state is automatically saved within closing the application. Right after main window load it tries to read state from hardcoded relative path and continue countdown, in case of failure countdown initializes again with value of three years. There is sound signal when countdown ends, also dialog box appears.

<b>How to use it?</b></br>
START button starts or continues countdown, STOP button is pausing it. RESET button sets remaining time back to three years. <i>MatiAplikacja_data</i> contains <i>value.txt</i> file which holds saved countdown state and <i>endOfCountdown.wav</i> file responsible for the sound which is played after countdown reaches end. This directory have to be in the exectuable file folder, next to it.

If you have any questions or suggestions, feel free to contact me.

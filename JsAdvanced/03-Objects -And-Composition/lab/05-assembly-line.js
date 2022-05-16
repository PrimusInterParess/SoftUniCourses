

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};


function createAssemblyLine() {
    return {
        hasClima: (car) => {
            car['temp'] = 21;
            car['tempSettings'] = 21;
            car['adjustTemp'] = function () {
                if (this.temp < this.tempSettings) {
                    this.temp += 1;
                } else if (this.temp > this.tempSettings) {
                    this.temp -= 1;
                }
            }
        },
        hasAudio: (car) => {
            car['currentTrack'] = null;
            car['nowPlaying'] = function () {
                if (this.currentTrack != null) {
                    console.log(`Now playing '${this.currentTrack.name}' by ${this.currentTrack.artist}`)
                }
            }
        },
        hasParktronic: (car) => {
            car['checkDistance'] = (dis) => {
                if (dis < 0.1) {
                    console.log('Beep! Beep! Beep!');
                } else if (dis < 0.25) {
                    console.log('Beep! Beep!');
                } else if (dis < 0.5) {
                    console.log('Beep!');
                } else {
                    console.log('');
                }
            }


        }

    }

}

const assemblyLine = createAssemblyLine();

assemblyLine.hasClima(myCar);


console.log(myCar);

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

myCar['currentTrack'] = { name: 'udri', artist: 'dani' };

if (myCar.currentTrack != null) {
    console.log('null')
}

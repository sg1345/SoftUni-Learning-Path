function movies(arr){

    let arrayToString = (array ,startIndex,endIndex) =>{
        if(endIndex === undefined){
            return array.slice(startIndex).join(' ');
        }
        return array.slice(startIndex, endIndex).join(' ');
    };

    let movies = [];

    for (const info of arr) {
        let temp =info.split(' ');

        if(temp[0] === 'addMovie'){
            let currentMovie = {
                name: temp.slice(1).join(' ')
            }
            movies.push(currentMovie);
            continue;
        }

        let directorIndex = temp.findIndex(x => x === 'directedBy');
        if(directorIndex !== -1 && movies.find(movie => movie.name === arrayToString(temp, 0, directorIndex))){

            let movieIndex = movies.findIndex(movie => movie.name === arrayToString(temp, 0, directorIndex));
            movies[movieIndex].director = arrayToString(temp, directorIndex + 1);

            continue;
        }
        let onDateIndex = temp.findIndex(x => x ==='onDate');
        if(onDateIndex !== -1 && movies.find(movie => movie.name === arrayToString(temp, 0, onDateIndex))){

            let movieIndex = movies.findIndex(movie => movie.name === arrayToString(temp, 0, onDateIndex));
            movies[movieIndex].date = arrayToString(temp,onDateIndex + 1);

            continue;
        }
        
    }

    for (const movie of movies){
        if(movie.name !== undefined && movie.director !== undefined && movie.date !== undefined){
            console.log(JSON.stringify(movie));     
        }
    }
}

movies([
'addMovie Fast and Furious',
'addMovie Godfather',
'Inception directedBy Christopher Nolan',
'Godfather directedBy Francis Ford Coppola',
'Godfather onDate 29.07.2018',
'Fast and Furious onDate 30.07.2018',
'Batman onDate 01.08.2018',
'Fast and Furious directedBy Rob Cohen'
]);
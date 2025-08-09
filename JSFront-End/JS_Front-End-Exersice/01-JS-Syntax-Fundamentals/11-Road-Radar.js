function RoadRadar(speed, environment){

    let speedLimit = 0;
    
    if(environment === 'motorway'){

        speedLimit = 130;

        if(speed <= speedLimit){
            SpeedInLimits(speed, speedLimit);
        }
        else{
            SpeedNotInLimits(speed, speedLimit);
        }

    }
    else if (environment === 'interstate'){

        speedLimit = 90;

        if(speed <= speedLimit){
            SpeedInLimits(speed, speedLimit);
        }
        else{
            SpeedNotInLimits(speed, speedLimit);
        }

    }
    else if (environment === 'city'){

        speedLimit = 50;

        if(speed <= speedLimit){
            SpeedInLimits(speed, speedLimit);
        }
        else{
            SpeedNotInLimits(speed, speedLimit);
        }

    }
    else{

        speedLimit = 20;
        if(speed <= speedLimit){
            SpeedInLimits(speed, speedLimit);
        }
        else{
            SpeedNotInLimits(speed, speedLimit, environment);
        }
    }

    function SpeedInLimits(speed, environment) {
        console.log(`Driving ${speed} km/h in a ${environment} zone`); 
    }

    function SpeedNotInLimits(speed, speedLimit){
        
        let difference = speed - speedLimit;
        let status = '';

        if(difference <= 20){
            status = 'speeding';
        }
        else if (difference <= 40){
            status = 'excessive speeding';
        }
        else{
            status = 'reckless driving';
        }
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
        
    }

}





RoadRadar(40, 'city');
RoadRadar(21, 'residential');
RoadRadar(120, 'interstate');
RoadRadar(200, 'motorway');
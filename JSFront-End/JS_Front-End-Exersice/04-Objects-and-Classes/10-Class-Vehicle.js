function vehicleCassFunction(){

    class Vehicle{
         constructor(type, model, parts, fuel){
            this.type = type;
            this.model = model;
            this.parts = parts;
            this.parts.quality = this.parts.engine * this.parts.power;
            this.fuel = fuel;
         }

         drive(fuelUsed){
            if(fuelUsed > this.fuel){
                this.fuel = 0;
            }
            else{
                this.fuel-=fuelUsed;
            }
         }
    }

    let parts = { engine: 6, power: 100 };
    let vehicle = new Vehicle('a', 'b', parts, 200);
    vehicle.drive(100);
    console.log(vehicle.fuel);
    console.log(vehicle.parts.quality);


}

vehicleCassFunction();
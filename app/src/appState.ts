export interface Restaurant{
    name:string;
    adress:string;
    city:string;
    zipcode:string;
    takeout:boolean;
}

export interface RestaurantState{
    added:boolean;
    restaurants?: Restaurant[];
}

export interface AppState{
    restaurant: RestaurantState; 
}
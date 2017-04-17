export interface Restaurant{
    name:string;
    adress:string;
    city:string;
    postalCode:string;
    takeOut:boolean;
}

export interface RestaurantState{
    added:boolean;
    restaurants?: Restaurant[];
}

export interface AppState{
    restaurant: RestaurantState; 
}
export interface Restaurant{
    name:string;
    takeout:boolean;
}

export interface RestaurantState{
    added:boolean;
    restaurants?: Restaurant[];
}

export interface AppState{
    restaurant: RestaurantState; 
}
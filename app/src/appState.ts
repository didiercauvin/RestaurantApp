export interface Restaurant{
    name:string;
    adress:string;
    city:string;
    postalCode:string;
    cuisine: Cuisine;
    takeOut:boolean;
}

export interface Cuisine {
    name: string;
}

export interface RestaurantState{
    added:boolean;
    restaurants?: Restaurant[];
}

export interface CuisineState {
    cuisines?: Cuisine[];
}

export interface AppState{
    restaurant: RestaurantState; 
}
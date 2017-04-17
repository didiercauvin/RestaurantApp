interface RestaurantInfo{
    name:string;
    adress:string;
    city:string;
    postalCode:string;
    takeOut:boolean;
}

export type AddAction = {
    type:'ADD_RESTAURANT',
    restaurant: RestaurantInfo
}

export const addRestaurant= (restaurant: RestaurantInfo) =>{
    return {
        type:'ADD_RESTAURANT',
        restaurant
    }
}


export type RestaurantAdded = {
    type:'RESTAURANT_ADDED',
}

export type Action = AddAction | RestaurantAdded;
import {Action, AddAction} from '../actions/restaurant';
import {AppState,RestaurantState} from '../appState';

function restaurantAdded(state:RestaurantState):RestaurantState {
    return {...state, added: true};
}

export const restaurantReducer =  (state={added: false}, action:Action) =>{
    switch(action.type) {
        case 'RESTAURANT_ADDED':
            return state;
        default:
            return state;
    }
};


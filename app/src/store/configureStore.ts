import { applyMiddleware, createStore, compose, combineReducers } from 'redux';
import { AppState } from '../appState';
import { restaurantReducer } from '../reducers/restaurantReducer';
import createSagaMiddleware from 'redux-saga';
import { watchPostRestaurant } from '../sagas/restaurantSaga';


export const configureStore = () => {

    var reducer = combineReducers<AppState>({
        restaurants: restaurantReducer
    });
    const sagaMiddleware = createSagaMiddleware()
    const initialState =  {
            restaurant: {
                added: false
            }
        };
        
    const store = createStore<AppState>(reducer,initialState
       , 
       compose (applyMiddleware(sagaMiddleware),));
    sagaMiddleware.run(watchPostRestaurant);

    return store;
}
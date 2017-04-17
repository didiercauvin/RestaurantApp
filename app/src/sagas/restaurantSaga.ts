import { call, put, takeEvery, takeLatest } from 'redux-saga/effects';
import {restaurantApi} from '../api/restaurantApi';
import {AddAction} from '../actions/restaurant';


function* postRestaurant(action:AddAction){
    try{
        console.log('saga',action);
        const result = yield call(restaurantApi.addRestaurant, action.restaurant)
        yield put({type: 'RESTAURANT_ADDED'});
    }catch(e) {
        yield put({type:'ADD_RESTAURANT_FAILED'});
    }
}

export function* watchPostRestaurant(){
    yield takeLatest('ADD_RESTAURANT',postRestaurant);
}

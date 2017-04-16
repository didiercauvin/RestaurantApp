import * as React from 'react';

interface InputProps {
    name:string;
    id:string;
    value?: string;
    onchange: (e:any) => void;
}

export const Input = ({ value = '', name, id, onchange }: InputProps) => {
    return (
        <div className="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
            <input className="mdl-textfield__input" type="text" id={id} onChange={onchange} />
            <label className="mdl-textfield__label" htmlFor={id} >{name}</label>
        </div>
    )
}

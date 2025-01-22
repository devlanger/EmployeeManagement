import React from "react";
import ReactDOM from "react-dom";

export function renderReactComponent(component, props, containerId) {
    const container = document.getElementById(containerId);
    ReactDOM.render(React.createElement(component, props), container);
}
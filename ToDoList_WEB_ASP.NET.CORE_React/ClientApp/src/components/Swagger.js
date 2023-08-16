import React from "react";
import SwaggerUI from "swagger-ui-react";
import "swagger-ui-react/swagger-ui.css";

const Swagger = () => {
    const url = 'https://localhost:44434//swagger/v1/swagger.json"';

    return <SwaggerUI url={url} />;
}

export default Swagger;
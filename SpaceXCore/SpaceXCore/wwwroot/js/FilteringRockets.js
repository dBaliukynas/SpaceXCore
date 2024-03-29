﻿dselect(document.querySelector("#select-box-rocket-name"), { search: true, clearable: true });

function rocketFilters() {
    return {
        reusableFS: null,
        notReusableFS: null,
        name: null,
        height: null,
        costPerLaunch: null,
        search() {
            const searchParams = new URLSearchParams();
            const url = "/rockets";

            this.name && searchParams.set("name", this.name);
            this.height && searchParams.set("height", this.height);
            this.costPerLaunch && searchParams.set("cost-per-launch", this.costPerLaunch);
            this.reusableFS && searchParams.set("reusable-fs", this.reusableFS);
            this.notReusableFS && searchParams.set("not-reusable-fs", this.notReusableFS);

            const queryString = searchParams.toString();
            const fullUrl = `${url}?${queryString}`;
            window.location.replace(fullUrl);
        }
    }
}
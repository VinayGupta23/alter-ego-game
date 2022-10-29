from distutils.log import debug
import pandas as pd
import matplotlib.pyplot as plt
import plotly.express as px
from dash import Dash, html, dcc

df = pd.read_json('alterego-midterm-analytics.json')

engagement = df.groupby('GUID').agg({'Level': pd.Series.nunique})
engagement = engagement.sort_values(by='Level')
print(engagement)

heatmap = df.pivot_table(index='GUID', columns='Level',
                         values='ApplicationVersion')
heatmap[~heatmap.isna()] = 1
heatmap = heatmap.fillna(0)
heatmap = heatmap.loc[engagement.index]
print(heatmap)


def local_plot():
    plt.imshow(heatmap)
    plt.xlabel('Level Index')
    plt.ylabel('Player Index')
    plt.show()


def live_plot():
    fig = px.imshow(heatmap)

    app = Dash(__name__)
    app.layout = html.Div(children=[
        dcc.Graph(
            id='heatmap',
            figure=fig,
            style={'height': '100vh'}
        )
    ])
    app.run_server(debug=False)


live_plot()
